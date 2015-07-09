using System;
using DomainLogic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Controllers;

namespace Tests.ControllersTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new BucketPartialController();
            Asserts.IsNotNull(controller);
        }
    }
}
