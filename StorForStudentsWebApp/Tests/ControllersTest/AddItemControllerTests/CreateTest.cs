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

namespace Tests.ControllersTests.AddItemControllerTests
{
    [TestClass]
    public class CreateTest
    {
        //NOTE: pattern for  naming of tests:  
        //      <method name>_<input arguments>_<expected result>

        [TestInitialize]
        public void del()
        {
            using (var context = new StoreDbContext())
            {
                context.Set<Item>().SqlQuery("delete from Items");
            }
        }
        
        [TestMethod]
        public void Create_ItemModel_Null()
        {
            // Arrange
            var controller = new AddItemController();
            var itemModel = new ItemModel() { Name = "q", Price = 12, Quantity = 12, Description = "q", ImagePath = "q" };
            //Act
            var result = controller.Create(itemModel);
            //Assert
            Asserts.IsNotNull(result, "Should have returned a ViewResult");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_Null_Null()
        {
            // Arrange
            var controller = new AddItemController();
            //Act
            var result = controller.Create(null);
            //Assert
            Asserts.IsNotNull(result, "Should have returned a ViewResult");
        }
    }
}
