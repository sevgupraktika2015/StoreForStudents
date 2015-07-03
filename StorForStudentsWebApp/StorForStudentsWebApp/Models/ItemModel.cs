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
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }

        protected ItemModel()
        {
            // for Entity Framework usage only
        }

        public ItemModel(Item item)
        {
            Asserts.IsNotNull(item);
            Name = item.Name;
            Price = item.Price;
            Quantity = item.Quantity;
            Id = item.Id;
        }

        public Item ToItem()
        {
            return new Item(this.Name,this.Price,this.Quantity);
        }

        public static List<ItemModel> ToModel(IList<Item> inlist)
        {
            List<ItemModel> outlist = new List<ItemModel>();
            foreach(var item in inlist)
            {
                outlist.Add(new ItemModel(item));
            }
            return outlist;
        }
    }
}