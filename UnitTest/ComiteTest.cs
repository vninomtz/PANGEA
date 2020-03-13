using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cliente_PANGEA.Controllers;
using Cliente_PANGEA.Views;

namespace UnitTest
{
    [TestClass]
    public class ComiteTest
    {
        
        [TestMethod]
        public void ExistingCommitteeTest()
        {
            bool expected = true;
            string name = "Administración de conferencias magistrales";
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

        


    }
}
