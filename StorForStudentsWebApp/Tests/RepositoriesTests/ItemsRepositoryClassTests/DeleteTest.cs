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
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                Item testItem = new Item("a", 1, 1);
                repository.SaveItem(testItem);
                //Act
                repository.DeleteItem(testItem);
                //Assert
                List<Item> resultList = new List<Item>();
                resultList = repository.Find(testItem.Name);
                Equals(resultList, null);

            }
        }
    }
}
