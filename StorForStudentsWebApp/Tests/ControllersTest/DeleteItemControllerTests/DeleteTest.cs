using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Controllers;
using DomainLogic.Utilities;
using System.Web.Mvc;
using StorForStudentsWebApp.Models;

namespace Tests.ControllersTest.DeleteItemControllerTests
{
    [TestClass]
    public class DeleteTest
    {
        [TestMethod]
        public void Index_ItemModel_Null()
        {
            // Arrange
            var controlleradd = new AddItemController();
            var itemModel = new ItemModel() { Name = "q", Price = 12, Quantity = 12 };
            var controller = new DeleteItemController();
            //Act
            controlleradd.Create(itemModel);
            var result = controller.Index(itemModel);
            //Assert
            Asserts.IsNotNull(result, "Should have returned a ViewResult");
        }

        [TestMethod]
        public void Index_Null_Null()
        {
            // Arrange
            var controller = new DeleteItemController();
            //Act
            var result = controller.Index(null);
            //Assert
            Asserts.IsNotNull(result, "Should have returned a ViewResult");
        }
    }
}
