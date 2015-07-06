using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using Implementation.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Controllers;
using StorForStudentsWebApp.Models;

namespace Tests.ControllersTest.SearchControllerTests
{
    [TestClass]
    public class SearchControllerIndexTest
    {
        public void Insert()
        {
            Item testItem = new Item("h", 10, 1);
            using (var context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                repository.SaveItem(testItem);
                context.SaveChanges();
            }

        }

        public void Delete()
        {
            using (var context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                repository.DeleteAll();
                context.SaveChanges();
            } 
        }
        [TestMethod]
        public void Index_SearchString_List()
        {
            Delete();
            Insert();
            var controller = new SearchController();
            var result = controller.Index("h") as ViewResult;
            var product = result.ViewData.Model;
            Assert.IsNotNull(product);
            Delete();
        }
        [TestMethod]
        public void Index_Null_List()
        {
            var controller = new SearchController();
            var result = controller.Index(null) as ViewResult;
            var product = result.ViewData.Model;
            Assert.IsNotNull(product);
        }
    }
}
