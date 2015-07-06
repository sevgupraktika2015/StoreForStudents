<<<<<<< HEAD
﻿using DomainLogic.Entities;
using DomainLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainLogic.Entities;
>>>>>>> 2ee61362fbad26461b177adf714e4f070c5a296c

namespace StorForStudentsWebApp.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        
        public Item ConvertToItem()
        {
            return new Item(Name, Price, Quantity, Id);
=======
        public string Name { get;  set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Item ConvertToItem()
        {
            Item item = new Item(Name, Price, Quantity, Id);
            return item;
>>>>>>> 2ee61362fbad26461b177adf714e4f070c5a296c
        }

        public ItemModel()
        {

        }

        public ItemModel(Item item)
        {
<<<<<<< HEAD
            Asserts.IsNotNull(item);
=======
>>>>>>> 2ee61362fbad26461b177adf714e4f070c5a296c
            Id = item.Id;
            Name = item.Name;
            Price = item.Price;
            Quantity = item.Quantity;
        }
<<<<<<< HEAD

        public static List<ItemModel> ToModel(IList<Item> inlist)
        {
            List<ItemModel> outlist = new List<ItemModel>();
            foreach(var item in inlist)
            {
                outlist.Add(new ItemModel(item));
            }
            return outlist;
        }
=======
>>>>>>> 2ee61362fbad26461b177adf714e4f070c5a296c
    }
}