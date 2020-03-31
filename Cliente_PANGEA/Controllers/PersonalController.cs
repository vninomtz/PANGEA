using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Cliente_PANGEA.Controllers
{
    class PersonalController
    {
        public static List<Cuentas> GetAccountsEvent(String correo)
        {
            using (var database = new  PangeaConnection())
            {
                try
                {
                    var accountList = database.Cuentas.Where(cuenta => cuenta.Correo == correo).ToList();
                    return accountList;
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error en la conexión a la BD");
                    return null;
                }
            } 
        }
        public static bool ExistingAccount(int idCuenta)
        {
            bool result = false;
            using (var dataBase = new PangeaConnection())
            {
                int exist = dataBase.Personal.Where(personal => personal.IdCuenta == idCuenta).Count();
                if (exist > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public static int AssignPersonal(Cuentas cuentas)
        {
            int idEvento = 5;
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                     var idCuenta = cuentas.Id;
                     Personal personal = new Personal(false, idEvento, idCuenta);
                    if (ExistingAccount(idCuenta)== true)
                    {
                        return result = 0;
                    }
                    var assignStaff = database.Personal.Add(personal);
                    result = database.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error en la conexión a la BD");
                }
            }
            return result;
        }

        public static List<Personal> GetPersonals()
        {

            using (var database = new PangeaConnection())
            {
                try
                {
                    var personalList = database.Personal.Include("Cuentas").Where(p=> p.Asignado == false).ToList();
                    return personalList;
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
        public static int DeletePersonal(int idPersonal)
        {
            int result = -1;
            using(var database = new PangeaConnection())
            {
                try
                {
                    var personal = database.Personal.Where(personalDB=> personalDB.Id == idPersonal).FirstOrDefault();
                    database.Personal.Remove(personal);
                    result = database.SaveChanges();
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return result;
        }
    }
}
