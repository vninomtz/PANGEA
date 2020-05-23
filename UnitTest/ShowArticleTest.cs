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
    public class ShowArticleTest
    {
        [TestMethod]
        public void GetArticleInActivities()
        {
            int idEvent = 1;
            List<Actividades> listArticles = ArticleController.GetArticlesEvent(idEvent);
            List<ArticleController> expected = null;
            Assert.AreNotEqual(listArticles, expected);
        }

        [TestMethod]
        public void GetArticleByName()
        {
            int idEvent = 1;
            String name = "Metricas";
            List<Actividades> listArticlesByName = ArticleController.GetArticlesByName(idEvent,name);
            List<Actividades> expected = null;
            Assert.AreNotEqual(listArticlesByName, expected);
        }
    }
}
