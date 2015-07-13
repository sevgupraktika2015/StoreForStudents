using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DomainLogic.Entities;
using DomainLogic.Utilities;
using Microsoft.Ajax.Utilities;

namespace StorForStudentsWebApp.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int User { get; set; }
        public List<OrderItem> Items;

        public OrderModel()
        {
            Items = new List<OrderItem>();
            //entity only
        }

        public OrderModel(Order order)
        {
                Asserts.IsNotNull(order);
                Items = new List<OrderItem>();
                Id = order.Id;
                User = order.User;
        }

        public OrderModel(Order order, List<Item> items)
        {
            Asserts.IsNotNull(order);
            Asserts.IsNotNull(items);
            Id = order.Id;
            User = order.User;
            Items = new List<OrderItem>();
            foreach (var itemInOrder in order.Items)
            {
                Item myItem = items.First(s => s.Id == itemInOrder.Id);
                if (myItem != null)
                    Items.Add(new OrderItem(myItem, itemInOrder)); 
            }
        }

        public Order ConvertToOrder()
        {
            Order newOrder = new Order(User, Id);
            return newOrder;
        }

        public List<ItemsInOrder> ConvertToItemsInOrder()
        {
            List<ItemsInOrder> newList = new List<ItemsInOrder>();
            foreach (var item in Items)
            {
                newList.Add(new ItemsInOrder(Id, item.Item.Id, item.Quantity));
            }
            return newList;
        }

        public void AddItem(OrderItem item)
        {
            Asserts.IsNotNull(item);
            Items.Add(item);
        }
    }
}