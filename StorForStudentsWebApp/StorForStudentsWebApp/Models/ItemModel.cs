using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainLogic.Entities;

namespace StorForStudentsWebApp.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Item ConvertToItem()
        {
            Item item = new Item(Name, Price, Quantity, Id);
            return item;
        }

        public ItemModel()
        {

        }

        public ItemModel(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Price = item.Price;
            Quantity = item.Quantity;
        }
    }
}