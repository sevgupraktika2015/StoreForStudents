using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Controllers;
using DomainLogic.Utilities;
using System.Web.Mvc;
using StorForStudentsWebApp.Models;
using Implementation.Repositories;
using DomainLogic.Entities;
using System.Collections.Generic;

namespace Tests.ControllersTest.DeleteItemControllerTests
{
    [TestClass]
    public class DeleteControllerTest
    {
        [TestMethod]
        public void IndexDeleteController_ItemModel_Null()
        {
            // Arrange
            using (var context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                List<Item> items = new List<Item>();
                //AddRequest();
                items = repository.Find("asdf");
                var controller = new DeleteItemController();
                ItemModel itemModel;
                //Act
                itemModel = new ItemModel(items[0]);
                controller.Index(itemModel);
                //Assert
                Assert.AreEqual(repository.Find("asdf").Count, 0);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IndexDeleteController_Null_Null()
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
