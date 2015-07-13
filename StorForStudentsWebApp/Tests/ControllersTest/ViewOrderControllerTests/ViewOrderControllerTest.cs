using System;
using System.Web.Mvc;
using DomainLogic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Controllers;

namespace Tests.ControllersTest.ViewOrderControllerTests
{
    [TestClass]
    public class ViewOrderControllerTest
    {
        [TestMethod]
        public void Index_NotNull_ActionResult()
        {
            ViewOrderController controller = new ViewOrderController();
            var result = controller.Index(1) as ViewResult;
            Asserts.IsNotNull(result, "Should have returned a ViewResult");
        }
    }
}
