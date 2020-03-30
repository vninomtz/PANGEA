using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cliente_PANGEA.Controllers;


namespace UnitTest
{
    [TestClass]
    public class EventTest
    {
        private Eventos evento = null;

        [TestInitialize]
        public void TesTInitialize()
        {
            evento = new Eventos();
        }

        [TestMethod]
        public void SaveEvent()
        {
            int expected = 1;
            int actual;

            evento.Nombre = "Evento Prueba";
            evento.CodigoEvento = "PB01";
            evento.Descripcion = "Descripción prueba";
            evento.Lugar = "UNAM";
            evento.FechaInicio = new DateTime(22 / 08 / 2020);
            evento.FechaFin = new DateTime(22 / 08 / 2020);
            evento.Gratuito = true;
            evento.Eliminado = false;
            actual = EventController.SaveEvent(evento);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetEvents()
        {
            var actual = EventController.GetEvents();
            Assert.AreNotEqual(null, actual);

        }

        [TestMethod]
        public void UpdateEvent()
        {
            evento.Id = 8;
            evento.Nombre = "Evento prueba update";
            evento.Gratuito = false;
            evento.Lugar = "Lugar de prueba";
            evento.Costo = 233;
            evento.FechaFin = new DateTime(23/09/2020);
            evento.FechaInicio = new DateTime(29/09/2020);
            evento.Descripcion = "Actualización de la prueba unitaria";

            var result = EventController.GetEventById(evento.Id);
            int expected = 8;

            Assert.AreEqual(expected, result.Id);
        }

        [TestMethod]

        public void GetLastEvent()
        {
            var result = EventController.GetLastEvent();
            Eventos expected = null;

            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]

        public void GetPersonalAndEvent()
        {
            var result = EventController.GetPersonalAndEvent(1);
            Personal expected = null;
            Assert.AreNotEqual(expected, result);
        }




    }
}
