using System;
using System.Collections.Generic;
using System.Linq;
using DomainLogic.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorForStudentsWebApp.Models;

namespace Tests.ModelsTests
{
    [TestClass]
    public class OrderModelTests
    {
        [TestMethod]
        public void Constructor_IntInt_notNull()
        {
            Order order = new Order(1, 1);
            OrderModel orderModel = new OrderModel(order);
            Assert.IsNotNull(orderModel);
        }

        [TestMethod]
        public void Constructor_IntIntList_notNull()
        {
            List<Item> items = new List<Item>();
            Order order = new Order(1, 1);
            OrderModel orderModel = new OrderModel(order, items);
            Assert.IsNotNull(orderModel);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_IntIntnull_exception()
        {
            new OrderModel(null);
        }

        [TestMethod]
        public void ConvertToOrder_Null_Equal()
        {
            Order order = new Order(1, 2);
            OrderModel orderModel = new OrderModel(order);
            Assert.AreEqual(order.Id, orderModel.ConvertToOrder().Id);
            Assert.AreEqual(order.User, orderModel.ConvertToOrder().User);
        }

        [TestMethod]
        public void ConvertToItemsInOrder_Null_Equal()
        {
            ItemsInOrder itemsInOrder = new ItemsInOrder(1, 1, 3);
            List<ItemsInOrder> orderitems = new List<ItemsInOrder>();
            orderitems.Add(itemsInOrder);
            Order order = new Order(orderitems, 1, 1);
            Item item = new Item("a",1, 1, 1);
            List<Item> items = new List<Item>();
            items.Add(item);

            OrderModel orderModel = new OrderModel(order, items);

            Assert.AreEqual(order.Id, orderModel.ConvertToItemsInOrder().First().OrderId);
            Assert.AreEqual(item.Id, orderModel.ConvertToItemsInOrder().First().Id);
            Assert.AreEqual(3, orderModel.ConvertToItemsInOrder().First().Quantity);
        } 
    }
}
