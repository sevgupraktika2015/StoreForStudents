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
            ItemModel itemdbo = new ItemModel();
            Assert.IsNotNull(itemdbo);
        }

        [TestMethod]
        public void ConvertToItem_Item_Equal()
        {
            Item item = new Item("name", 12, 2, 2);
            ItemModel itemdbo = new ItemModel(item);
            Assert.AreEqual(item.Id, itemdbo.ConvertToItem().Id);
            Assert.AreEqual(item.Price, itemdbo.ConvertToItem().Price);
            Assert.AreEqual(item.Quantity, itemdbo.ConvertToItem().Quantity);
            Assert.AreEqual(item.Name, itemdbo.ConvertToItem().Name);

            Assert.AreEqual(item, itemdbo.ConvertToItem()); //?????
        }
    }
}

    
    

