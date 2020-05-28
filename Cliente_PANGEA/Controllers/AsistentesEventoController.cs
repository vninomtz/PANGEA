using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Cliente_PANGEA.Controllers
{
    public class AsistentesEventoController
    {
        public static List<AsistentesEvento> GetEventAssistantsByName(string name, int idEvent)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var listAssistantsByName = database.AsistentesEvento.Include("Asistentes").Where(a=>a.Asistentes.Nombre.Contains(name) ||a.Asistentes.Apellido.Contains(name)
                    && a.IdEvento == idEvent).ToList();
                    return listAssistantsByName;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }
        public static List<AsistentesEvento> GetAllAssistantsEvent(int idEvent)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var assistantsList = database.AsistentesEvento.Include("Asistentes").Where(a => a.IdEvento == idEvent).ToList();
                    return assistantsList;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }
        public static List<AsistentesEvento> GetEventAssistant(int idAssistant)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var assistantEvent = database.AsistentesEvento.Include("Asistentes").Where(a=> a.IdAsistente == idAssistant).ToList();
                    return assistantEvent;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }
        /**
         * Recuperar un asistenteEvento para poder pasar a la pantalla de "ValidateAssitance" y mostrarlo
         */
        public static AsistentesEvento GetEventAssistantByIdAssistant(int idAssistant)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var assistantEvent = database.AsistentesEvento.Include("Asistentes").Where(a => a.IdAsistente == idAssistant).FirstOrDefault();
                    return assistantEvent;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }
        public static List<IncripcionActividades> GetAssistantActivitiesEvent(List<IncripcionActividades> listIdIncription)
        {
            using (var database = new PangeaConnection())
            {
                List<IncripcionActividades> listIncriptions = new List<IncripcionActividades>();
                    try
                    {
                    foreach(var id in listIdIncription){
                        var inscription = database.IncripcionActividades.Include("Actividades").Where(i => i.id == id.id).FirstOrDefault();
                        listIncriptions.Add(inscription);
                    }
                        return listIncriptions;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }   
            }
            return null;
        }
        public static List<IncripcionActividades> GetIdEventIncriptionOfAssistant(int idAssitant)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var incription = database.IncripcionActividades.Where(i => i.idAsistente == idAssitant).ToList();
                    return incription;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }
        public static int ValidateAssistanceInActivity(int idIncriptionActivity)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                    var incriptionActivity = database.IncripcionActividades.Where(i=> i.id == idIncriptionActivity).FirstOrDefault();
                    incriptionActivity.asistencia = true;
                    return result = database.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return result;
        }
    }
}
