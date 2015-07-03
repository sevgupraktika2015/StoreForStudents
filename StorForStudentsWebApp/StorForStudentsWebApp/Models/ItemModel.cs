using DomainLogic.Entities;
using DomainLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StorForStudentsWebApp.Models
{
    public class ItemModel
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public int Quantity { get; protected set; }
        public int Id { get; protected set; }

        protected ItemModel()
        {
            // for Entity Framework usage only
        }

        public ItemModel(string name, decimal price, int quantity, int id = 0)
        {
            Asserts.IsNotNullOrEmpty(name, "name");
            Asserts.IsNotNegative(price, price.ToString());
            Asserts.IsNotNegative(quantity, quantity.ToString());
            
            Name = name;
            Price = price;
            Quantity = quantity;
            Id = id;
        }

        public Item ToItem()
        {
            return new Item(this.Name,this.Price,this.Quantity);
        }

        public static IList<ItemModel> ToModel(IList<Item> inlist)
        {
            List<ItemModel> outlist = new List<ItemModel>();
            foreach(var item in inlist)
            {
                outlist.Add(new ItemModel(item.Name,item.Price,item.Quantity));
            }
            return outlist;
        }
    }
}