using System;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using Implementation.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests.RepositoriesTests.ItemsRepositoryClassTests
{
    [TestClass]
    public class ConstructorTest
    {
        //NOTE: pattern for  naming of tests:  
        //      <method name>_<input arguments>_<expected result>

        [TestMethod]
        public void Constructor_context_notNull()
        {
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                Assert.IsNotNull(repository);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_null_exception()
        {
            new ItemsRepository(null);
        }

        [TestMethod]
        public void UpdateItem_Context_Equal()
        {
            // Arrange    
            Item existingItem = new Item("test",1,1);
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                repository.SaveItem(existingItem);
            }
            // Act
            existingItem.Name = "nameChanged";
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                repository.AddItem(existingItem);
        
            }

            // Assert
            List<Item> getItem;
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                getItem = repository.Find("nameChanged");

            }    
   
            Assert.IsNotNull(getItem[0]);
            Assert.AreEqual("nameChanged", getItem[0].Name);
    
        }
    }
}
