using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Cliente_PANGEA.Controllers
{
    public class ComiteController
    {
        
        public static Comites GetLastCommittee()
        {
            using (var dataBase = new PangeaConnection())
            {
                return dataBase.Comites.OrderByDescending(u => u.Id).FirstOrDefault();
            }
        }
        public static Comites GetCommitteeById(int Id)
        {
            using(var dataBase = new PangeaConnection())
            {
                int exist = dataBase.Comites.Where(u => u.Id == Id).Count();
                if(exist > 0)
                {
                    return dataBase.Comites.FirstOrDefault(u => u.Id == Id);
                }
                else
                {
                    return null;
                }
            }
        }
        public static int UpdateCommitee(Comites committe)
        {
            int result = -1;
            using(var dataBase = new PangeaConnection())
            {
                var committeeUpdated = dataBase.Comites.FirstOrDefault(u => u.Id == committe.Id);
                committeeUpdated.Nombre = committe.Nombre;
                committeeUpdated.Descripcion = committe.Descripcion;
                committeeUpdated.UltimaModificacion = DateTime.Now;

                try
                {
                    result = dataBase.SaveChanges();
                }catch(Exception ex)
                {
                    Console.WriteLine($"Error en la conexión a la base de datos {ex}");
                }
            }

            return result;
        }
        public static bool ExistingCommittee(string committe)
        {
            bool result = false;
            using (var dataBase = new PangeaConnection())
            {
                int exist = dataBase.Comites.Where(comite => comite.Nombre == committe).Count();
                if (exist > 0)
                {
                    result = true;
                }
            }
            return result;

        }

        public static int SaveCommittee(Comites comite)
        {
            int result = -1;
            using(var dataBase = new PangeaConnection())
            {
                try
                {
                    dataBase.Comites.Add(comite);
                    result = dataBase.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error en la conexión a la BD: {e}");

                }
            }
            return result;
        }
        public static List<Comites> GetAllCommitte(int idEvent)
        {
            using (var dataBase = new PangeaConnection())
            {
                try
                {
                    List<Comites> comitesList = dataBase.Comites.Where(u => u.IdEvento == idEvent).ToList();
                    return comitesList;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error en la conexión a la BD:" + e);
                    return null;
                }
            }

        }

        public static bool DeleteCommittee(int idCommittee)
        {
            bool result = false;
            using (var database = new PangeaConnection())
            {
                Comites committee = database.Comites.Where(c => c.Id == idCommittee).FirstOrDefault();
                database.Comites.Attach(committee);
                database.Comites.Remove(committee);
                if(database.SaveChanges() > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
