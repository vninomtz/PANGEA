using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_PANGEA.Controllers
{
    class ActivityController
    {
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
