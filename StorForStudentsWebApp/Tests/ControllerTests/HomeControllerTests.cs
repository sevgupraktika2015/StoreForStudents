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
        public void ControllerTest_Id_notNull()
        {
            var controller = new HomeController();
            Item test = new Item("test", 1, 1);
            using (var context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                repository.SaveItem(test);
            }
            var result = controller.Edit(test.Id) as ViewResult;
            var product = result.ViewData.Model as ItemModel;
            Assert.IsNotNull(product);
        }
    }
}
