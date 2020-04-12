using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Cliente_PANGEA.Controllers
{
    class AsistenteController
    {
        public static int SaveAssistant(Asistentes asistentes, int idEvent)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                    database.Asistentes.Add(asistentes);
                    result = database.SaveChanges();
                    if (result>0)
                    {
                            if (SaveAssistantInEvent(asistentes.Id, idEvent) > 0)
                            {
                                return result;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public static int SaveAssistantInEvent(int idAssistant, int IdEvent)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                AsistentesEvento assistantEvent = new AsistentesEvento(idAssistant,IdEvent);
                try
                {
                    database.AsistentesEvento.Add(assistantEvent);
                    result = database.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return result;
        }
        public static bool ExistingAssistant(Asistentes asistente)
        {
            using(var database = new PangeaConnection())
            {
                try
                {
                    int exist = database.Asistentes.Where(comite => comite.Nombre == asistente.Nombre && comite.Apellido == asistente.Apellido).Count();
                    if (exist>0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error en la conexión con la base de datos.");
                }
            }
            return false;
        }
    }
}
