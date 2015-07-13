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
        public void Delete()
        {
            using (var context = new StoreDbContext())
            {
                context.Database.ExecuteSqlCommand("delete from ItemsInOrders");
                context.Database.ExecuteSqlCommand("delete from Items");
                context.SaveChanges();
            } 
        }

        [TestMethod]
        public void SaveItem_saved_items_equals()
        {

            Delete();
            Item item1 = new Item("asdf", 45, 45);
            var entitylen = 0;

            using (var context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                repository.SaveItem(item1);
                entitylen = repository.GetAll().ToArray().Length;
            }
            Assert.AreEqual(1, entitylen);
        }
    }
}
