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
        public static Cuentas GetAccount(int idAccount)
        {
            Cuentas cuenta;
            using (var database = new PangeaConnection())
            {
                try
                {
                    cuenta = database.Cuentas.Where(c => c.Id == idAccount).FirstOrDefault();
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

        public static int UserExist(string email)
        {
            try
            {
                using(var dataBase = new PangeaConnection())
                {
                    int exist = dataBase.Cuentas.Where(c => c.Correo == email).Count();
                    
                    if(exist > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public static bool SaveUser(string name, string lastname, string email, string phone, string password)
        {
            try
            {
                using (var dataBase = new PangeaConnection())
                {
                    Cuentas newAccount = new Cuentas
                    {
                        Nombre = name,
                        Apellido = lastname,
                        Correo = email,
                        Telefono = phone,
                        Contrasenia = password

                    };

                    dataBase.Cuentas.Add(newAccount);
                    int result = dataBase.SaveChanges();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool UpdateAccount(int idAccount, string name, string lastname,string phone)
        {
            try
            {
                using (var dataBase = new PangeaConnection())
                {
                    Cuentas accountUpdate = dataBase.Cuentas.Where(c => c.Id == idAccount).FirstOrDefault();
                    accountUpdate.Nombre = name;
                    accountUpdate.Apellido = lastname;
                    accountUpdate.Telefono = phone;

                    int result = dataBase.SaveChanges();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
