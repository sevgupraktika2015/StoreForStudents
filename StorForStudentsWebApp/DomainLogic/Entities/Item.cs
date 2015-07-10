using System;
using DomainLogic.Utilities;

namespace DomainLogic.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string Description { get; set; }
        public string ImagePath { get; set; }

        public Item()
        {
            // for Entity Framework usage only
        }

        
        public Item(string name, decimal price, int quantity, int id = 0, string Desc = "none",
            string ImPath = "none"): base(id)
        {
            Asserts.IsNotNullOrEmpty(name, "name");
            Asserts.IsNotNegative(price, price.ToString());
            Asserts.IsNotNegative(quantity, quantity.ToString());
            Name = name;
            Price = price;
            Quantity = quantity;
            Id = id;
            Description = Desc;
            ImagePath = ImPath;
        }

        public Boolean Equals(Item item1, Item item2)
        {
            Asserts.IsNotNull(item1, "First item should be not null");
            Asserts.IsNotNull(item2, "Second item should be not null");

            if (item1.Name.Equals(item2.Name)         &&
                item1.Price.Equals(item2.Price)       &&
                item1.Quantity.Equals(item2.Quantity) &&
                item1.Id.Equals(item2.Id)             &&
                item1.Description.Equals(item2.Description) &&
                item1.ImagePath.Equals(item2.ImagePath))
                return true;
            else
                return false;
        }
    }
}
