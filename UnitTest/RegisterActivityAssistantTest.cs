using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccess;
using Cliente_PANGEA.Controllers;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class RegsiterActivityAssistantTest
    {
        IncripcionActividades inscripcionActividades = new IncripcionActividades();

        [TestMethod]
        public void AssistantNotRegsiterInActivity()
        {
            int expected = -1;
            int idActividad = 3;
            int idAsistente = 1;
            int result = ActivityController.ValidateNotRegisterActivityAssistant(idActividad, idAsistente);
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void RegisterActivityAssistant()
        {
            int idAsistente = 1;
            int idActividad = 3;
            this.inscripcionActividades.idActividad = 3;
            this.inscripcionActividades.idAsistente = 1;
            int expected = 1;
            int result = ActivityController.RegisterActivityAssistant(idAsistente, idActividad);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetEventActivitiesSpaceAvaible()
        {
            int idEvento = 1;
            List<Horarios> listaActividades = ActivityController.GetEventActivitiesSpaceAvaible(idEvento);
            List<Horarios> expected = null;
            Assert.AreNotEqual(expected, listaActividades);
        }
    }
}
