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
    public class ScheduleTest
    {

        [TestMethod]
        public void SaveScheduleTest()
        {
            int expected = 1;
            Horarios schedule = new Horarios
            {
                IdActividad = 1,
                Direccion = "Prueba",
                Lugar = "Prueba",
                FechaFin = DateTime.Now,
                FechaInicio = DateTime.Now

            };
            List<Horarios> schedules = new List<Horarios>();
            schedules.Add(schedule);
            int result = ScheduleController.SaveSchedules(schedules);
            Assert.AreEqual(expected, result);
        }
    }
}
