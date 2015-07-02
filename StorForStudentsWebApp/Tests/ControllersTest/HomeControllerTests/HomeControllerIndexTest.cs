using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DomainLogic.Entities;
using DomainLogic.Utilities;
using Implementation.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Controllers;
using System.Collections.ObjectModel;

namespace Tests.ControllersTest.HomeControllerTests {
    [TestClass]
    public class HomeControllerIndexTest {
        [TestMethod]
        public void HomeControllerIndexTest1 () {
            var controller = new HomeController ();
            var result = controller.Index () as ViewResult;
            List<Item> resultItemsList = result.ViewBag.Items;
            Assert.IsNotNull (resultItemsList);
        }
    }
}
