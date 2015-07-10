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
            Item item = new Item("1", 1, 1);
            List<OrderItem> items = new List<OrderItem>();
            items.Add(new OrderItem(item, 1));
            Order order = new Order(1, 1);
            OrderModel orderModel = new OrderModel(order, items);
            Assert.IsNotNull(orderModel);
        }
        [TestMethod]
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
            Order order = new Order(1, 1);
            Item item = new Item("1", 1, 1, 2);
            List<OrderItem> items = new List<OrderItem>();
            items.Add(new OrderItem(item, 3));

            OrderModel orderModel = new OrderModel(order, items);

            Assert.AreEqual(order.Id, orderModel.ConvertToItemsInOrder().First().Id);
            Assert.AreEqual(item.Id, orderModel.ConvertToItemsInOrder().First().ItemId);
            Assert.AreEqual(3, orderModel.ConvertToItemsInOrder().First().Quantity);
        } 
    }
}
