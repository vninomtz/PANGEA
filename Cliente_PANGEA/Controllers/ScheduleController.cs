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
    }
}
