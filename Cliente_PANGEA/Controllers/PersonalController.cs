using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Cliente_PANGEA.Controllers
{
    public class PersonalController
    {
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
                if(exist > 0)
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
                    if(idCommitee == 0)
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
                }catch(Exception ex)
                {
                    Console.WriteLine($"Error en la conexión a la BD {ex}");
                }
            }

            return result;
        }
    }


}
