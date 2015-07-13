using System;
using System.Linq;
using DomainLogic.Entities;
using Implementation.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.RepositoriesTests.ItemsRepositoryClassTests
{
    [TestClass]
    public class SaveItemTest
    {
        [TestInitialize]
        public void del()
        {
            using (var context = new StoreDbContext())
            {
                context.Set<Item>().SqlQuery("delete from Items");
            }
        }

        [TestMethod]
        public void SaveItem_saved_items_equals()
        {
            Item item1 = new Item("asdf", 45, 45);
            var entitylen = 0;

            using (var context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                repository.DeleteAll();
                repository.SaveItem(item1);
                entitylen = repository.GetAll().ToArray().Length;
            }
            Assert.AreEqual(1, entitylen);
        }
    }
}
