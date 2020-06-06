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
    public class ShowActivitiesTest
    {
        List<Actividades> activityList = new List<Actividades>();
        [TestMethod]
        public void ShowActivities()
        {
            int idEvent = 1;
            activityList = ActivityController.GetEventActivities(idEvent);
            Assert.IsNotNull(activityList);
        }
    }
}
