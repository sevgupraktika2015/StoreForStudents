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

namespace Tests.ControllersTest.HomeControllerTests 
{
    [TestClass]
    public class HomeControllerIndexTest 
    {
        [TestMethod]
        public void Index_Null_Null() 
        {
            // Arrange
            var controller = new HomeController();
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
