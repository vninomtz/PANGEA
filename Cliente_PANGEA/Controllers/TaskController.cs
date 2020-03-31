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
        public static int UpdateTask(Tareas task)
        {
            try
            {
                using(var dataBase = new PangeaConnection())
                {
                    Tareas taskUpdated = dataBase.Tareas.Where(t => t.Id == task.Id).FirstOrDefault();
                    taskUpdated.Nombre = task.Nombre;
                    taskUpdated.Descripcion = task.Descripcion;
                    taskUpdated.Responsable = task.Responsable;
                    taskUpdated.Finalizada = task.Finalizada;
                    taskUpdated.UltimaModificacion = DateTime.Now;

                    try
                    {
                        return dataBase.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error en la conexión a la base de datos {ex}");
                        return -1;
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public static bool DeleteTask(int idTask)
        {
            bool result = false;
            try
            {
                using(var dataBase = new PangeaConnection())
                {
                    var task = dataBase.Tareas.Where(t => t.Id == idTask).FirstOrDefault();
                    dataBase.Tareas.Attach(task);
                    dataBase.Tareas.Remove(task);
                    if(dataBase.SaveChanges() > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }

            }catch(Exception ex)
            {
                Console.WriteLine($"Error en la conexión a la base de datos {ex}");
                result = false;
            }
            return result;
        }
    }
}
