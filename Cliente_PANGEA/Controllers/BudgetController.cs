using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_PANGEA.Controllers
{
    class BudgetController
    {
        public static Presupuestos GetBudget(int idEvento)
        {
            Presupuestos budget = new Presupuestos();
          
            using (var dataBase = new PangeaConnection())
                
            {
                try
                {
                    budget = dataBase.Presupuestos.Where(p => p.IdEvento == idEvento).FirstOrDefault();
                    if (budget == null)
                    { 
                         budget = new Presupuestos
                        {
                            Gasto_real = 0,
                            IdEvento = idEvento,

                        };
                        dataBase.Presupuestos.Add(budget);
                        dataBase.SaveChanges();

                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    budget.Gasto_tentativo = -1;
                }
                return budget;
            }
        }

        public static int UpdateBudget(int idBudget, double tentativeBudget)
        {
            int result = -1;

            using(var database = new PangeaConnection())
            {
               var budget = database.Presupuestos.Where(p => p.Id == idBudget).FirstOrDefault();
                budget.Gasto_tentativo = tentativeBudget;
                result = database.SaveChanges();
            }

            return result;
        }

        

    }
}
