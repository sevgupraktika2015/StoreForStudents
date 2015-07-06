using System;
using DomainLogic.Utilities;

namespace DomainLogic.Entities
{
    public class Item : BaseEntity {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public int Quantity { get; protected set; }

        protected Item () {
            // for Entity Framework usage only
        }


        public Item (string name, decimal price, int quantity, int id = 0)
            : base(id) 
        {
            Asserts.IsNotNullOrEmpty (name, "name");
            Asserts.IsNotNegative (price, price.ToString ());
            Asserts.IsNotNegative (quantity, quantity.ToString ());


            Name = name;
            Price = price;
            Quantity = quantity;
            Id = id;

        }

        public Boolean Equals(Item item1, Item item2)
        {
            Asserts.IsNotNull(item1, "First item should be not null");
            Asserts.IsNotNull(item2, "Second item should be not null");

            if (item1.Name.Equals(item2.Name)         &&
                item1.Price.Equals(item2.Price)       &&
                item1.Quantity.Equals(item2.Quantity) &&
                item1.Id.Equals(item2.Id))
                return true;
            else
                return false;
        }
    }
}
