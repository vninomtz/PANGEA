using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente_PANGEA.Controllers;

namespace UnitTest
{
    [TestClass]
    public class ConstancyTest
    {
        List<IncripcionActividades> incripcionActividades = new List<IncripcionActividades>();
        [TestMethod]
        public void GetAssistant()
        {
            int idAsistente = 5;
            List<AsistentesEvento> asistentesEventos = new List<AsistentesEvento>();
            asistentesEventos = AsistentesEventoController.GetEventAssistant(idAsistente);
            Assert.IsNotNull(asistentesEventos);
        }
        [TestMethod]
        public void GetIncriptionActivities()
        {
            int idAsistente = 5;
            incripcionActividades = AsistentesEventoController.GetListEventIncriptionOfAssistantWithAssitanceValidate(idAsistente);
            Assert.IsNotNull(incripcionActividades);
        }
        [TestMethod]
        public void GetIncriptionActivitiesforShow()
        {
            int idAssitente = 5;
            incripcionActividades = AsistentesEventoController.GetListEventIncriptionOfAssistantWithAssitanceValidate(idAssitente);
            List<IncripcionActividades> finalList = new List<IncripcionActividades>();
            finalList = AsistentesEventoController.GetAssistantActivitiesEvent(incripcionActividades);
            Assert.IsNotNull(finalList);
        }
    }
}
