﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DomainLogic.Entities;
using DomainLogic.Utilities;
using Implementation.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Controllers;

namespace Tests.ControllersTests.AdminCatalogControllerTests
{
    [TestClass]
    public class IndexTest
    {

        [TestMethod]
        public void Index_returns_correct_view()
        {
            // Arrange
            const string expectedViewName = "Index";
            var controller = new AdminCatalogController();
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Asserts.IsNotNull(result, "Should have returned a ViewResult");
            Assert.AreEqual(expectedViewName, result.ViewName, "View should be {0}", expectedViewName);
            
        }

        [TestMethod]
        public void Index_Viewbag_Contains_Same_Items_List_As_Into_Db()
        {
            //Arrange
            List<Item> expectedItemsList = null;
            using (var context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                expectedItemsList = new List<Item>(repository.EntitySet.ToArray());
            }
            var controller = new AdminCatalogController();
            //Act
            var result = controller.Index() as ViewResult;
            var resultItemsList = result.ViewBag.Items as List<Item>;
            //Assert
            for (int i = 0; i < resultItemsList.Count; i++)
            {
                Asserts.AreEqual(expectedItemsList.ElementAt(i), resultItemsList.ElementAt(i));
            }
        }
    }
}
