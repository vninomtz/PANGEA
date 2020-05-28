using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using Cliente_PANGEA.Controllers;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class MaterialsTest
    {
        [TestMethod]
        public void GetMaterialsTest()
        {
            int idEvent = 1;
            List<Materiales> listMaterials = MaterialsController.GetMaterials(idEvent);
            Assert.IsNotNull(listMaterials);
        }
    }
}
