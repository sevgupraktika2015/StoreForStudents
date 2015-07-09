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

        public OrderModel(int id, int user)
        {
            Id = id;
            User = user;
        }

        public OrderModel(int id, int user, List<OrderItem> items )
        {
            Id = id;
            User = user;
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
            Items.Add(item);
        }
    }
}