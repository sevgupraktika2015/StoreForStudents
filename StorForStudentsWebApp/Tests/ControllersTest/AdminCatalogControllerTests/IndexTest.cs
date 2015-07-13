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
using StorForStudentsWebApp.Models;

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
            var result = controller.Index(1) as ViewResult;
            //Assert
            Asserts.IsNotNull(result, "Should have returned a ViewResult");
        }

        [TestMethod]
        public void EditControllerTest_Id_notNull()
        {
            //дикий говнокод, но зато выполняется с любой БД
            Item item;
            Item[] find;
            using (StoreDbContext context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                item = new Item("item", 12, 12, 33, "desc", "IP");
                Delete();
                repository.AddItem(item);
                find = repository.Find(item.Name).ToArray();
            }

            var controller = new AdminCatalogController();
            var result = controller.Edit(find[0].Id) as ViewResult;
            ItemModel product = (ItemModel)result.ViewData.Model;

            Assert.IsNotNull(product.Name);
        }

        [TestMethod]
        public void DetailsControllerTest_Id_notNull()
        {
            Item item;
            Item[] find;
            using (StoreDbContext context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                item = new Item("item", 12, 12, 33, "desc", "IP");
                Delete();
                repository.SaveItem(item);
                find = repository.Find(item.Name).ToArray();
            }

            var controller = new AdminCatalogController();
            var result = controller.Details(find[0].Id) as ViewResult;
            var product = (ItemModel)result.ViewData.Model;

            Assert.IsNotNull(product.Name);

        }

        public void Delete()
        {
            using (var context = new StoreDbContext())
            {
                context.Set<ItemsInOrder>().SqlQuery("delete from ItemsInOrders");
                context.Set<Item>().SqlQuery("delete from Items");
            } 
        }
    }
}
