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
    }
}
