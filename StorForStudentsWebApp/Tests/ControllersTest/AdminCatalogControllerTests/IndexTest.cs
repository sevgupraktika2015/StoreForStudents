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
            var controller = new AdminCatalogController();
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Asserts.IsNotNull(result, "Should have returned a ViewResult");
        }

        [TestMethod]
        public void Index_Viewbag_Contains_Same_Items_List_As_Into_Db()
        {
            //Arrange
            List<Item> expectedItemsList = null;
            using (var context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                expectedItemsList = repository.GetAll();
            }
            var controller = new AdminCatalogController();
            //Act
            var result = controller.Index() as ViewResult;
            List<Item> resultItemsList = result.ViewBag.Items;
            //Assert
            for (int i = 0; i < resultItemsList.Count; i++)
            {
                Asserts.AreEqual(expectedItemsList.ElementAt(i), resultItemsList.ElementAt(i));
            }
        }
    }
}
