using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Implementation.Repositories;
using DomainLogic.Repositories;
using DomainLogic.Entities;
using System.Collections.Generic;

namespace Tests.RepositoriesTests.ItemsRepositoryClassTests
{
    [TestClass]
    public class DeleteTest
    {
        [TestMethod]
        public void Delete_Item_Void()
        {
            // Arrange
            Item testItem;
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                testItem = new Item("a", 1, 1);
                repository.SaveItem(testItem);
            }
            //Act
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                repository.DeleteItem(testItem);
            }
            //Assert
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                List<Item> resultList = repository.Find(testItem.Name);
                Equals(resultList, null);

            }
        }
    }
}
