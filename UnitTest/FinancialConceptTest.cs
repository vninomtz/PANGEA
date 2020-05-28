using Cliente_PANGEA.Controllers;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
   public class FinancialConceptTest
    {
        [TestMethod]
        public void GetFinancialConceptTest()
        {
            List<ConceptosFinancieros> expected = null;
            List<ConceptosFinancieros> result = FinancialConceptController.GetFinancialConcepts(1);
            Assert.AreNotEqual(expected, result);      
            
        }

        [TestMethod]
        public void NewFinancialConceptTest()
        {

            int expected = -1;

            ConceptosFinancieros concept = new ConceptosFinancieros
            {
                Concepto = "Prueba",
                Fecha_creacion = DateTime.Now,
                IdActividad = 1,
                IdPresupuesto = 1,
                Monto = 500,
                Tipo = "Ingreso",
                

                
            };

            int result = FinancialConceptController.NewFinancialConcept(concept);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            ConceptosFinancieros concept = new ConceptosFinancieros
            {
                Concepto = "Prueba",
                Fecha_creacion = DateTime.Now,
                IdActividad = 1,
                IdPresupuesto = 1,
                Monto = 500,
                Tipo = "Ingreso",
                Id = 2,
            };
            bool expected = false;
            bool result = FinancialConceptController.DeleteConcept(concept);
            Assert.AreEqual(expected, result);
        }



    }



}
