using DataAccess;
using System;
using System.Linq;


namespace Cliente_PANGEA.Controllers
{
    public class AccountController
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
        public static int SaveTokenInAccount(String email, String token)
        {
            int result = -1;
            try
            {
                using (var database = new PangeaConnection())
                {
                    var account = database.Cuentas.Where(c => c.Correo == email).FirstOrDefault();
                    account.Token = token;
                    result = database.SaveChanges();
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result; 
        }
        public static Cuentas GetTokenAccount(String email, String token)
        {
            
            try
            {
                using (var database = new PangeaConnection())
                {
                    var account = database.Cuentas.Where(c=>c.Correo == email && c.Token == token).FirstOrDefault();
                    return account;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
        public static int UpdatePassword(String email, String newPassword)
        {
            int result = -1;
            try
            {
                using (var database = new PangeaConnection())
                {
                    var account = database.Cuentas.Where(c=>c.Correo == email).FirstOrDefault();
                    account.Contrasenia = newPassword;
                    result = database.SaveChanges();
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }
    }
}
