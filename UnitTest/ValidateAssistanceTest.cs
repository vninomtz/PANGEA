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
    public class ValidateAssistanceTest
    {
        [TestMethod]
        public void GetIncriptionAssistant()
        {
            int idAssistant = 6;
            List<IncripcionActividades> listIncriptions = AsistentesEventoController.GetIdEventIncriptionOfAssistant(idAssistant);
            Assert.IsNotNull(listIncriptions);
        }
        [TestMethod]
        public void GetAssistantActivitiesEvent()
        {
            List<IncripcionActividades> listActivies = new List<IncripcionActividades>();
            List<IncripcionActividades> listActivities = AsistentesEventoController.GetAssistantActivitiesEvent(listActivies);
            Assert.IsNotNull(listActivities);
        }
        [TestMethod]
        public void ValidateAssitance()
        {
            int idIncripcion = 5;
            int result = AsistentesEventoController.ValidateAssistanceInActivity(idIncripcion);
            int expected = 1;
            Assert.AreEqual(expected,result);
        }
        [TestMethod]
        public void ValidateAssitanceDone()
        {
            int idIncripcion = 2;
            int result = AsistentesEventoController.ValidateAssistanceInActivity(idIncripcion);
            int expected = 0;
            Assert.AreEqual(expected, result);
        }
    }
}
