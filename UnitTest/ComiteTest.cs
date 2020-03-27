using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cliente_PANGEA.Controllers;
using Cliente_PANGEA.Views;
using DataAccess;

namespace UnitTest
{
    [TestClass]
    public class ComiteTest
    {

        Comites comittee = new Comites();

        
        [TestMethod]
        public void ExistingCommitteeTest()
        {
            bool expected = true;
            string name = "Comité de prueba Unitaria";
            bool result = ComiteController.ExistingCommittee(name);
            Assert.AreEqual(expected, result);
            
        }

        [TestMethod]
        public void NotExistingComitteeTest()
        {
            bool expected = false;
            string name = "Comité no existente";
            bool result = ComiteController.ExistingCommittee(name);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SaveComitteeTest()
        {
            this.comittee.Nombre = "Comité de prueba Unitaria";
            this.comittee.Descripcion = "Descripción del comité de PU";
            this.comittee.FechaCreacion = DateTime.Now;
            this.comittee.IdEvento = 1;
            
            int expected = 1;
            int result = ComiteController.SaveCommittee(this.comittee);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void GetLastCommitteeTest()
        {
            Comites com = ComiteController.GetLastCommittee();
            Assert.IsNotNull(com);
        }
        [TestMethod]
        public void UpdateCommitteeTest()
        {
            Comites com = ComiteController.GetLastCommittee();
            com.UltimaModificacion = DateTime.Now;
            int expected = 1;
            int result = ComiteController.UpdateCommittee(com);
            Assert.AreEqual(expected, result);
        }

        
        [TestMethod]
        public void DeleteCommitteeTest()
        {
            this.comittee.Nombre = "Comité de prueba Unitaria";
            this.comittee.Descripcion = "Descripción del comité de PU";
            this.comittee.FechaCreacion = DateTime.Now;
            this.comittee.IdEvento = 1;
            Comites com = ComiteController.GetLastCommittee();
            bool result = ComiteController.DeleteCommittee(com.Id);
            Assert.IsTrue(result);

        }





    }
}
