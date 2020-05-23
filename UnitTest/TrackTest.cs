using Cliente_PANGEA.Controllers;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class TrackTest
    {
        [TestMethod]
        public void GetTracksTest()
        {
            List<Tracks> expected = null;
            List<Tracks> actual = TrackController.GetTracks(1);
            Assert.AreNotEqual(expected, actual);
        } 

        [TestMethod]

        public void AddTrackTest()
        {
            int expected = -1;
            int actual = TrackController.AddTrack(new Tracks { Nombre = "Prueba", Descripcion = "Descripción de rueba" });

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        
        public void DeleteTrackTest()
        {
            int expected = -1;
            int actual = TrackController.DeleteTrack(1);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
