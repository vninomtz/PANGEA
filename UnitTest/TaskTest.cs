using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cliente_PANGEA.Controllers;
using DataAccess;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void GetAllTaskTest()
        {
            int idEvent = 1;
            List<Tareas> listTask = TaskController.GetAllTasks(idEvent);
            Assert.IsNotNull(listTask);
        }
    }
}
