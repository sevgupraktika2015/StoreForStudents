using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Controllers;
using StorForStudentsWebApp.Models;

namespace Tests.ControllerTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void ControllerTest_Id_notNull()
        {
            var controller = new HomeController();
            var result = controller.Edit(1) as ViewResult;
            var product = (ItemModel) result.ViewData.Model;
            Assert.IsNotNull(product.Name);
        }
    }
}
