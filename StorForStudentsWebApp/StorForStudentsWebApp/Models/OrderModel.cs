using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainLogic.Entities;
using DomainLogic.Utilities;

namespace StorForStudentsWebApp.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Dictionary<int, int> Items;

        public OrderModel(Order order, List<ItemsInOrder> items)
        {
            Asserts.IsNotNull(order);
            Asserts.IsNotNull(items);
            Id = order.Id;
            UserId = order.UserId;
            foreach (ItemsInOrder item in items)
            {
                if (item.OrderId != Id)
                {
                    throw new ArgumentException("Item doesent match this order");
                }
                Items.Add(item.ItemId, item.Quantity);
            }
        }

        public static List<OrderModel> ToModel(List<Order> orders, List<ItemsInOrder> items)
        {
            List<OrderModel> outList = new List<OrderModel>();
            foreach (var order in orders)
            {
                List<ItemsInOrder> itemsForThisOrder = items.Where(s => s.OrderId == order.Id).ToList();
                outList.Add(new OrderModel(order, itemsForThisOrder));
            }
            return outList;
        }

        public Order ConvertToOrder()
        {
            Order newOrder = new Order(UserId, Id);
            return newOrder;
        }

        public List<ItemsInOrder> ConvertToItemsInOrder()
        {
            List<ItemsInOrder> newList = new List<ItemsInOrder>();
            foreach (var item in Items)
            {
                newList.Add(new ItemsInOrder(Id, item.Key, item.Value));
            }
            return newList;
        }
    }
}