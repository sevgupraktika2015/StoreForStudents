using System;
using DomainLogic.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Models;

namespace Tests.ModelsTests
{
    [TestClass]
    public class ItemModelTests
    {
        [TestMethod]
        public void Constructor_Item_notNull()
        {
            Item item = new Item("name", 12, 2, 2);

            ItemModel itemdto = new ItemModel(item);

            Assert.IsNotNull(itemdto);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_null_exception()
        {
            new ItemModel(null);
        }

        [TestMethod]
        public void ConvertToItem_Item_Equal()
        {
            Item item = new Item("name", 12, 2, 2);

            ItemModel itemdbo = new ItemModel(item);
            
            Assert.AreEqual(2, itemdbo.ConvertToItem().Id);
            Assert.AreEqual(12, itemdbo.ConvertToItem().Price);
            Assert.AreEqual(2, itemdbo.ConvertToItem().Quantity);
            Assert.AreEqual("name", itemdbo.ConvertToItem().Name);
        }
    }
}

    
    

