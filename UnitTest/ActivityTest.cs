using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente_PANGEA.Controllers;
using DataAccess;

namespace UnitTest
{
    [TestClass]
    public class ActivityTest
    {

        [TestMethod]
        public void SaveActivityTest()
        {
            int expected = 0;
            Actividades activity = new Actividades
            {
                FechaCreacion = DateTime.Now,
                Costo = 900,
                Gratuito = false,
                Tipo = "Prueba",
                Titulo = "Actividad", 
                IdEvento = 1,
            };

            int result = ActivityController.SaveActivity(activity);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetLastActivityTest()
        {
            int result = ActivityController.GetLastActivity();
            int expected = 1015;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
    public void getActivitiesTest()
        {
            List<Horarios> result = ActivityController.GetActivities(1);
            List<Horarios> expected = null;
            Assert.AreNotEqual(expected, result);

        }
    }
}
