using System;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using Implementation.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Item existingItem;;
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                existingItem = repository.GetById(1);
            }

            // Act
            existingItem.Name = "nameChanged";
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                repository.AddItem(existingItem);
        
            }

            // Assert
            Item getItem;
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                getItem = repository.GetById(1);

            }    
   
            Assert.IsNotNull(getItem);
            Assert.AreEqual("nameChanged", getItem.Name);
    
        }
    }
}
