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
                    return dataBase.Materiales.Include("Actividades").Where(m => m.Actividades.IdEvento == idEvent).ToList();
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
        public static int UpdateMaterial(string name, string description, int quantity, int idMaterial)
        {
            try
            {
                using (var dataBase = new PangeaConnection())
                {
                    Materiales materialUpdated = dataBase.Materiales.Where(m => m.Id == idMaterial).FirstOrDefault();
                    materialUpdated.Nombre = name;
                    materialUpdated.Descripcion = description;
                    materialUpdated.Cantidad = quantity;

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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -2;
            }
        }

        public static bool DeleteMaterial(int idMaterial)
        {
            bool result = false;
            try
            {
                using (var dataBase = new PangeaConnection())
                {
                    var material = dataBase.Materiales.Where(m => m.Id == idMaterial).FirstOrDefault();
                    dataBase.Materiales.Attach(material);
                    dataBase.Materiales.Remove(material);
                    if (dataBase.SaveChanges() > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la conexión a la base de datos {ex}");
                result = false;
            }
            return result;
        }
    }
}
