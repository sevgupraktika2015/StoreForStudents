using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Controllers;
using DomainLogic.Utilities;
using System.Web.Mvc;
using StorForStudentsWebApp.Models;
using Implementation.Repositories;
using DomainLogic.Entities;

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
                Item item = new Item();
                item = repository.GetById(1);
                var controller = new DeleteItemController();
                ItemModel itemModel;
                //Act
                itemModel = new ItemModel(item);
                controller.Index(itemModel);
                //Assert
                Assert.AreEqual(repository.GetById(1),null);
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
