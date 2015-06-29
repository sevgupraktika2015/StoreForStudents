using System;
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
    }
}
