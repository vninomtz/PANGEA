using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Cliente_PANGEA.Controllers
{
    public class MaterialsController
    {
        public static List<Materiales> GetMaterials(int idEvent)
        {
            try
            {
                using (var dataBase = new PangeaConnection())
                {
                    return dataBase.Materiales.Include("Actividades").Where(m => m.IdEvento == idEvent).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;
        }
    }
}
