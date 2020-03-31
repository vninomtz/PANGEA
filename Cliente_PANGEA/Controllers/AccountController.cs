using DataAccess;
using System;
using System.Linq;


namespace Cliente_PANGEA.Controllers
{
    class AccountController
    {
        public static Cuentas Login(String email, String password)
        {
            Cuentas cuenta;
            using(var database = new PangeaConnection())
            {
                try
                {
                    cuenta = database.Cuentas.Where(c => c.Correo == email && c.Contrasenia == password).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    cuenta = new Cuentas
                    {
                        Id = -1
                    };

                    Console.WriteLine(ex);                   
                }
                
            }

            return cuenta;
        }
    }
}
