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

namespace Tests.ControllersTests.AdminCatalogControllerTests
{
    [TestClass]
    public class IndexTest
    {

        [TestMethod]
        public void Index_NotNull_ActionResult()
        {
            // Arrange
            var controller = new AdminCatalogController();
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Asserts.IsNotNull(result, "Should have returned a ViewResult");
        }
    }
}
