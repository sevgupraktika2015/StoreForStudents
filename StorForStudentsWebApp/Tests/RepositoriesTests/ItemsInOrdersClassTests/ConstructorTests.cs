using System;
using DomainLogic.Repositories;
using Implementation.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.RepositoriesTests.ItemsInOrdersClassTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Constructor_Context_NotNull()
        {
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsInOrdersRepository repository = new ItemsInOrdersRepository(context);
                Assert.IsNotNull(repository);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_null_exception()
        {
            new ItemsInOrdersRepository(null);
        }
    }
}
