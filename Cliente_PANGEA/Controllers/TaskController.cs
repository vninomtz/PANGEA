using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Cliente_PANGEA.Controllers
{
    public class TaskController
    {
        public static  List<Tareas> GetAllTasks(int idEvent)
        {
            try
            {
                using (var dataBase = new PangeaConnection())
                {
                    return dataBase.Tareas.Include("Actividades").Where(a => a.Actividades.IdEvento == idEvent).ToList();
                }
            }catch(Exception e)
            {
                return null;
            }
            
        }
    }
}
