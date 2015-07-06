using DomainLogic.Entities;
using DomainLogic.Utilities;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StorForStudentsWebApp.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        [Display(Name = "Название товара")]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [Required]
        [DataType(DataType.Currency)]
        
        public decimal Price { get; set; }

        [Display(Name = "Количество")]
        [Required]
        [Range(1, Int16.MaxValue)]
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
            try
            {
                Asserts.IsNotNull(item);
                Id = item.Id;
                Name = item.Name;
                Price = item.Price;
                Quantity = item.Quantity;
            }
            catch
            {

            }
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