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

        public static int SaveMaterial(string name, string description, int quantity, int idEvent, int idActivity)
        {
            try
            {
                using (var dataBase = new PangeaConnection())
                {
                    Materiales newMaterial = new Materiales
                    {
                        Nombre = name,
                        Descripcion = description,
                        Cantidad = quantity,
                        IdActividad = idActivity,
                        IdEvento = idEvent

                    };

                    dataBase.Materiales.Add(newMaterial);
                    return dataBase.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
