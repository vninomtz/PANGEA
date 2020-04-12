using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_PANGEA.Controllers
{
   public class ScheduleController
    {

        public static int SaveSchedules(List<Horarios> schedulesList)
        {
            int result;
            using(var dataBase = new PangeaConnection())
            {
                try
                {
                    foreach (var schedule in schedulesList)
                    {
                        dataBase.Horarios.Add(schedule);

                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
                result = dataBase.SaveChanges();
            }
            return result;
           
        }
       public static List<Horarios> GetSchedules(int idActivity)
        {
            using(var database = new PangeaConnection())
            {
                try
                {
                    var listSchedule = database.Horarios.Where(h => h.IdActividad == idActivity).ToList();
                    return listSchedule;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }
        public static int DeleteSchedule(int idSchedule)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                    var schedule = database.Horarios.Where(s => s.Id == idSchedule).FirstOrDefault();
                    database.Horarios.Remove(schedule);
                    result = database.SaveChanges();
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return result;
        }
        public static int SaveSchedule(Horarios schedule)
        {
            int result = -1;
            using (var dataBase = new PangeaConnection())
            {
                try
                {
                    dataBase.Horarios.Add(schedule);
                    result = dataBase.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                
            }
            return result;

        }
    }
}
