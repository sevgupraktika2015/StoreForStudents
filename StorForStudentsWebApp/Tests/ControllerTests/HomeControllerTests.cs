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
            //дикий говнокод, но зато выполняется с любой БД
            Item item;
            Item[] find;
            using (StoreDbContext context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                item = new Item("item", 12, 12, 33, "desc", "IP");
                repository.DeleteAll();
                repository.AddItem(item);
                find = repository.Find(item.Name).ToArray();
            }

            var controller = new HomeController();
            var result = controller.Edit(find[0].Id) as ViewResult;
            ItemModel product = (ItemModel) result.ViewData.Model;

            Assert.IsNotNull(product.Name);
        }

        [TestMethod]
        public void DetailsControllerTest_Id_notNull()
        {
            Item item = new Item("item", 12, 12, 33, "desc", "IP");
            Item[] find;
            using (StoreDbContext context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                repository.DeleteAll();
                repository.SaveItem(item);
                find = repository.Find(item.Name).ToArray();
            }

            var controller = new HomeController();
            var result = controller.Details(find[0].Id) as ViewResult;
            var product = (ItemModel)result.ViewData.Model;

            Assert.IsNotNull(product.Name);
            
        }
    }
}
