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
    public class ArticleRegisterTest
    {
        [TestMethod]
        public void SaveArticleTest()
        {
            int idTrack = 1;
            Articulos article = new Articulos
            {
                nombre = "Metricas de software",
                autor = "Alan Gonzalez",
                descripcion = "Descripcion de metricas",
                archivo = "c:\\archivo.pdf",
                fecha_creacion = DateTime.Now,
                ultima_actualizacion = DateTime.Now,
                
            };
            int result = ArticleController.SaveArticle(article,idTrack);
            int esperado = 1;
            Assert.AreEqual(esperado,result);
        }

        [TestMethod]
        public void GetTrackEvent()
        {
            int idEvent = 1;
            List<Tracks> trackList = ArticleController.GetEventTracks(idEvent);
            Assert.AreNotEqual(null, trackList);
        }

        [TestMethod]
        public void ValidateRegisterArticle()
        {
            int idTrack = 1;
            Articulos article = new Articulos
            {
                nombre = "Metricas de software",
                autor = "Alan Gonzalez",
                descripcion = "Descripcion de metricas",
                archivo = "c:\\archivo.pdf",
                fecha_creacion = DateTime.Now,
                ultima_actualizacion = DateTime.Now,

            };
            bool result = ArticleController.ValidateRegisterArticleInTrack(article,idTrack);
            bool expected = true;
            Assert.AreEqual(expected,result);
        }
    }
}
