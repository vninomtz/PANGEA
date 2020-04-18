using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Cliente_PANGEA.Controllers
{
    public class FinancialConceptController
    {

        public static bool DeleteConcept(ConceptosFinancieros financialConcept)
        {
            bool isDelete = true;

            using(var database = new PangeaConnection())
            {
                try
                {
                    var deleteConcept = database.ConceptosFinancieros.Where(concept => concept.Id == financialConcept.Id).FirstOrDefault();
                    database.ConceptosFinancieros.Remove(deleteConcept);
                    if (database.SaveChanges() < 0)
                    {
                        isDelete = false;
                    }
                }
                catch ( Exception ex)
                {

                    Console.WriteLine(ex);
                    isDelete = false;
                }
            }

            return isDelete;
        } 

        public static int NewFinancialConcept(ConceptosFinancieros conceptinformation)
        {
            int result = 0;

            using(var dataBase = new PangeaConnection())
            {
                
                try
                {
                    dataBase.ConceptosFinancieros.Add(conceptinformation);
                    result = dataBase.SaveChanges();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    result = -1;
                }
                

            }

            return result;

        }

        public static List<ConceptosFinancieros> GetFinancialConcepts(int idBudget)
        {
            List<ConceptosFinancieros> financialConcepts = new List<ConceptosFinancieros>();

            using(var database = new PangeaConnection())

            {
                try
                {
                    financialConcepts = database.ConceptosFinancieros.Include("Actividades").Where(concept => concept.IdPresupuesto == idBudget).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ConceptosFinancieros errorConcept = new ConceptosFinancieros();
                    errorConcept.Id = -1;
                    financialConcepts.Add(errorConcept);                 
                }
               
                
            }

            return financialConcepts;
        }
    }
}
