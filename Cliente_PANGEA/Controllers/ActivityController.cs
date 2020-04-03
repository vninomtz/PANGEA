using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_PANGEA.Controllers
{
    public class ActivityController
    {

        public static int GetLastActivity()
        {
            int id = 0;
            using(var database = new PangeaConnection())
            {
                id = database.Actividades.ToList().Last().Id;
            }

            return id;
        }
        public static int SaveActivity(Actividades newActivity)
        {
            int result = 0;
            using(var dataBase = new PangeaConnection())
            {
                try
                {
                    dataBase.Actividades.Add(newActivity);
                    result = dataBase.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                 
                }
                 
            }
            return result;

        }
        public static List<Horarios> GetActivities(int idEvento)
        {

            using (var dataBase = new PangeaConnection())
            {
                var activityList = dataBase.Horarios.Include("Actividades").Where(a => a.Actividades.IdEvento == idEvento).OrderBy(a => a.FechaInicio).ToList();
                
                return activityList;
            }


        }
        public static List<Actividades> GetAllActivities(int idEvent)
        {
            using (var dataBase = new PangeaConnection())
            {
                var activityList = dataBase.Actividades.Where(a => a.IdEvento == idEvent).ToList();

                return activityList;
            }
        }
    }
}
