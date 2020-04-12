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
          public static bool ExistingAccount(int idCuenta, int idEvent)
        {
            bool result = false;
            using (var dataBase = new PangeaConnection())
            {
                int exist = dataBase.Personal.Where(personal => personal.IdCuenta == idCuenta && personal.IdEvento == idEvent).Count();
                if (exist > 0)
                {
                    result = true;
                }
            }
            return result;
        }
    
         public static bool DeleteAssignmetsByCommittee(int IdCommittee)
        {
            bool result = false;
            using (var database = new PangeaConnection())
            {
                var listPersonal = database.Personal.Where(p => p.IdComite == IdCommittee).ToList();
                if (listPersonal.Count > 0)
                {
                    foreach (var member in listPersonal)
                    {
                        member.Asignado = false;
                        member.Cargo = null;
                        member.IdComite = null;
                    }
                    if (database.SaveChanges() > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                }
                else
                {
                    result = true;
                }
            }

            return result;
        }

        public static int AssignPersonal(Cuentas cuentas, int idEvento)
        {
            int result = -1;
            using (var database = new PangeaConnection())
            {
                try
                {
                     var idCuenta = cuentas.Id;
                     Personal personal = new Personal(false, idEvento, idCuenta);
                    if (ExistingAccount(idCuenta,idEvento)== true)
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

  
        public static List<Personal> GetPersonals(int idEvent)
        {

            using (var database = new PangeaConnection())
            {
                try
                {
                    var personalList = database.Personal.Include("Cuentas").Where(p => p.Asignado == false && p.IdEvento==idEvent).ToList();
                    return personalList;
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
        
        public static List<Cuentas> GetMembersCommittee(int idEvent, int idCommitte, string position)
        {
            using (var dataBase = new PangeaConnection())
            {
                int exist = dataBase.Eventos.Where(u => u.Id == idEvent).Count();
                if (exist > 0)
                {
                    List<Cuentas> cuentas = new List<Cuentas>();
                    List<Personal> staff = dataBase.Personal.Where(u => u.IdEvento == idEvent && u.IdComite == idCommitte && u.Cargo == position).ToList();
                    foreach (var item in staff)
                    {
                        cuentas.Add(dataBase.Cuentas.Where(u => u.Id == item.IdCuenta).FirstOrDefault());
                    }

                    return cuentas;
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<Cuentas> GetAvailableStaff(int idEvent)
        {
            using (var dataBase = new PangeaConnection())
            {
                int exist = dataBase.Eventos.Where(u => u.Id == idEvent).Count();
                if (exist > 0)
                {
                    List<Cuentas> cuentas = new List<Cuentas>();
                    List<Personal> staff = dataBase.Personal.Where(u => u.IdEvento == idEvent && u.Asignado == false).ToList();
                    foreach (var item in staff)
                    {
                        cuentas.Add(dataBase.Cuentas.Where(u => u.Id == item.IdCuenta).FirstOrDefault());
                    }

                    return cuentas;
                }
                else
                {
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

        public static List<Personal> GetPersonalByLastName(String lastName, int idEvent)
        {
            using (var database = new PangeaConnection())
            {
                try
                {
                    var listPersonalByLastName = database.Personal.Include("Cuentas").Where(personal => personal.Asignado == false &&  
                    personal.Cuentas.Apellido.Contains(lastName) && personal.IdEvento == idEvent).ToList();
                    return listPersonalByLastName;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
    
        public static int UpdateAssignmentsStaff(List<Cuentas> listaccounts, bool assigned, string position, int idCommitee)
        {
            int result = -1;
            using (var dataBase = new PangeaConnection())
            {
                foreach (var account in listaccounts)
                {
                    Personal personal = dataBase.Personal.Where(u => u.IdCuenta == account.Id).FirstOrDefault();
                    personal.Asignado = assigned;
                    personal.Cargo = position;
                    if (idCommitee == 0)
                    {
                        personal.IdComite = null;
                    }
                    else
                    {
                        personal.IdComite = idCommitee;
                    }


                }
                try
                {
                    result = dataBase.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en la conexión a la BD {ex}");
                }
            }

            return result;
        }

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
