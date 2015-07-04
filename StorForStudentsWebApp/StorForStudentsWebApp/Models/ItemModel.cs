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
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        
        public Item ConvertToItem()
        {
            return new Item(Name, Price, Quantity, Id);
        }

        public ItemModel()
        {

        }

        public ItemModel(Item item)
        {
            Asserts.IsNotNull(item);
            Id = item.Id;
            Name = item.Name;
            Price = item.Price;
            Quantity = item.Quantity;
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