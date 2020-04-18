using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Cliente_PANGEA.Controllers;

namespace UnitTest
{
    [TestClass]
    public class ShowAssistantsTest
    {
        [TestMethod]
        public void GetAssistantsEvent()
        {
            int idEvent = 1;
            List<AsistentesEvento> asistentesEventos = AsistentesEventoController.GetAllAssistantsEvent(idEvent);
            List<AsistentesEvento> expected = null;
            Assert.AreNotEqual(asistentesEventos, expected);
        }

        [TestMethod]
        public void GetAsistantsEventByName()
        {
            string name = "Sheyla";
            int idEvent = 1;
            
            List<AsistentesEvento> asistentesEventos = AsistentesEventoController.GetEventAssistantsByName(name, idEvent);
            List<AsistentesEvento> expected = null;
            Assert.AreNotEqual(asistentesEventos,expected);
        }
    }
}
