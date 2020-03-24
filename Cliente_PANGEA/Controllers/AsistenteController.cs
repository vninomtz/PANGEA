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
        public static int SaveAssistant(Asistentes asistentes)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                    database.Asistentes.Add(asistentes);
                    result = database.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("“Error en la conexión con la base de datos”.");
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
