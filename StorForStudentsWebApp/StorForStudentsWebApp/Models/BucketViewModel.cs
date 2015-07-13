using System;
using System.Collections;
using System.Collections.Generic;
using DomainLogic.Entities;

namespace StorForStudentsWebApp.Models
{
    public class BucketViewModel
    {
        public OrderModel OrderModel { get; set; }

        public BucketViewModel()
        {
            OrderModel = new OrderModel();
        }

        public decimal BucketPrice()
        {
            decimal price = 0;
            foreach (var point in OrderModel.ItemsMap)
            {
                price = price + point.Key.Price*point.Value;
            }
            return price;
        }
    }

    public class OrderModel
    {
        public Dictionary<ItemModel, decimal> ItemsMap;

        public OrderModel()
        {
            ItemsMap = new Dictionary<ItemModel, decimal>();
            var itemsList = new List<Item>();
            itemsList.Add(new Item("adf", 25, 5));
            itemsList.Add(new Item("adff", 255, 5));
            itemsList.Add(new Item("adf", 21, 3));
            itemsList.Add(new Item("adf", 15, 5));
            foreach (var item in itemsList)
            {
                ItemsMap.Add(new ItemModel(item), 3);
            }
        }
    }
}