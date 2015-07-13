using System;
using DomainLogic.Repositories;
using Implementation.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.RepositoriesTests.OrderRepositoryTest
{
    [TestClass]
    public class ConstructorTest
    {
        [TestMethod]
        public void Constructor_Context_NotNull()
        {
            using (StoreDbContext context = new StoreDbContext())
            {
                IOrdersReporitory repository = new OrdersRepository(context);
                Assert.IsNotNull(repository);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_null_exception()
        {
            new ItemsRepository(null);
        }

    }
}
