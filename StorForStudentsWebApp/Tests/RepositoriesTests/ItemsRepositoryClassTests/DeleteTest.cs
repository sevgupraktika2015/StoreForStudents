using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Implementation.Repositories;
using DomainLogic.Repositories;
using DomainLogic.Entities;

namespace Tests.RepositoriesTests.ItemsRepositoryClassTests
{
    [TestClass]
    public class DeleteTest
    {
        [TestMethod]
        public void Delete_Item_Void()
        {
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                Item testItem = new Item("a", 1, 1);
                repository.SaveItem(testItem);
            }
        }
    }
}
