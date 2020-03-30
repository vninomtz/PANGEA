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
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
        public static int SaveTask(string name, string description, string inCharge, int idActivity)
        {
            try
            {
                using (var dataBase = new PangeaConnection())
                {
                    Tareas newTask = new Tareas
                    {
                        Nombre = name,
                        Descripcion = description,
                        Responsable = inCharge,
                        IdActividad = idActivity,
                        FechaCreacion = DateTime.Now
                        
                    };

                    dataBase.Tareas.Add(newTask);
                    return dataBase.SaveChanges();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
