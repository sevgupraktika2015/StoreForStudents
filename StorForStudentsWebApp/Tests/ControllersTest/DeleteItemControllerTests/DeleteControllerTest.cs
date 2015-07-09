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
        [TestInitialize]
        public void del()
        {
            using (var context = new StoreDbContext())
            {
                context.Set<Item>().SqlQuery("delete from Items");
            }  
        }

        public void createItem()
        {
            using (var context = new StoreDbContext())
            {
                context.Set<Item>().SqlQuery("insert into Items values('a',1,1,'a','a')");
            }
        }

        
        [TestMethod]
        public void IndexDeleteController_ItemModel_Null()
        {
            // Arrange
            ItemsRepository repository;
            Item testItem;
            ItemModel itemModel;
            var controller = new DeleteItemController();
            createItem();
            using (var context = new StoreDbContext())
            {
                repository = new ItemsRepository(context);
                testItem = repository.Find("a")[0];
            }
            //Act
            itemModel = new ItemModel(testItem);
            controller.Index(itemModel);

            using (var context = new StoreDbContext())
            {
                //Assert
                repository = new ItemsRepository(context);
                Assert.AreEqual(repository.FindItem(testItem), null);
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
