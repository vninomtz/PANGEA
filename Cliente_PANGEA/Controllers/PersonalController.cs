using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_PANGEA.Controllers
{
    class PersonalController
    {
        public static int SavePersonal(Personal personal)
        {
            int result = -1;
            using (var dataBase = new PangeaConnection())
            {
                try
                {
                    dataBase.Personal.Add(personal);
                    result = dataBase.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error en la conexión a la BD" + e);

                }
            }
            return result;
        }
    }
}
