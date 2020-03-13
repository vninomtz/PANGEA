using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Cliente_PANGEA.Controllers
{
    class ComiteController
    {
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
                    Console.WriteLine("Error en la conexión a la BD");

                }
            }
            return result;
        }
    }
}
