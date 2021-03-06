﻿using System;
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
            using (var context = new StoreDbContext())
            {
                context.Database.ExecuteSqlCommand("insert into Items values('1', 1, 1, '1', '1')");
                context.SaveChanges();
            }

        }

        public void Delete()
        {
            using (var context = new StoreDbContext())
            {
                context.Database.ExecuteSqlCommand("delete from ItemsInOrders");
                context.Database.ExecuteSqlCommand("delete from Items");
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
