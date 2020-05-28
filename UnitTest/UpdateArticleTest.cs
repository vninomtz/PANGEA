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
    public class UpdateArticleTest
    {
        [TestMethod]
        public void GetTrackArticle()
        {
            int idTrack = 1;
            List<Tracks> track = ArticleController.GetTrackById(idTrack);
            Assert.IsNotNull(track);
        }
    }
}
