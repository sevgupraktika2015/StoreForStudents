using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Controllers;
using StorForStudentsWebApp.Models;
using DomainLogic.Entities;
using Implementation.Repositories;
using DomainLogic.Repositories;

namespace Tests.ControllerTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void EditControllerTest_Id_notNull()
        {
            using (StoreDbContext context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                Item item = new Item("item", 12, 12, 1, "desc", "IP");
                repository.AddItem(item);
            }

            var controller = new HomeController();
            var result = controller.Edit(1) as ViewResult;
            var product = (ItemModel) result.ViewData.Model;

            Assert.IsNotNull(product.Name);
            Assert.AreEqual(product.Name, "item");
        }

        [TestMethod]
        public void DetailsControllerTest_Id_notNull()
        {
            using (StoreDbContext context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                Item item = new Item("item", 12, 12, 1, "desc", "IP");
                repository.AddItem(item);
            }

            var controller = new HomeController();
            var result = controller.Details(1) as ViewResult;
            var product = (ItemModel)result.ViewData.Model;

            Assert.IsNotNull(product.Name);
            Assert.AreEqual(product.Name, "item");
            
        }
    }
}
