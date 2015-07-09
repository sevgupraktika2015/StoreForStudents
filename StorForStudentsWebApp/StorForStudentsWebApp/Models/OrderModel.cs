using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DomainLogic.Entities;
using DomainLogic.Utilities;

namespace StorForStudentsWebApp.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int User { get; set; }
        public List<OrderItem> Items;

        public OrderModel()
        {
            //entity only
        }

        public OrderModel(Order order)
        {
            try
            {
                Asserts.IsNotNull(order);
                Id = order.Id;
                User = order.User;
            }
            catch
            {
                
            }
        }

        public OrderModel(Order order, List<OrderItem> items )
        {
            Asserts.IsNotNull(order);
            Asserts.IsNotNull(items);
            Id = order.Id;
            User = order.User;
            Items = items;
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