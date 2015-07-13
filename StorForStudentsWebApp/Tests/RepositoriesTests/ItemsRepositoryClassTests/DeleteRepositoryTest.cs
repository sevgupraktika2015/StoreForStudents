using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Implementation.Repositories;
using DomainLogic.Repositories;
using DomainLogic.Entities;
using System.Collections.Generic;

namespace Tests.RepositoriesTests.ItemsRepositoryClassTests
{
    [TestClass]
    public class DeleteRepositoryTest
    {
        [TestInitialize]
        public void del()
        {
            using (var context = new StoreDbContext())
            {
                context.Set<Item>().SqlQuery("delete from Items");
            }
        }

        public void createItem()
        {
            using (var context = new StoreDbContext())
            {
                context.Set<Item>().SqlQuery("insert into Items values('a',1,1,'a','a')");
            }
        }
        
        [TestMethod]
        public void DeleteRepository_Item_Void()
        {
            // Arrange
            createItem();
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                Item testItem = repository.Find("a")[0];
                //Act
                repository.DeleteItem(testItem);
                //Assert
                List<Item> resultList = new List<Item>();
                resultList = repository.Find(testItem.Name);
                Equals(resultList, null);

            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteRepository_Null_Void()
        {
            // Arrange
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                //Act
                repository.DeleteItem(null);
                //Assert
            }
        }
    }
}
