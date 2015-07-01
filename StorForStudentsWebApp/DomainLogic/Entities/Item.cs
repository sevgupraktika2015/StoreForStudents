using DomainLogic.Utilities;

namespace DomainLogic.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public int Quantity { get; protected set; }

        protected Item()
        {
            // for Entity Framework usage only
        }

        public Item(string name, decimal price, int quantity,  int id = 0): base(id)
        {
            Asserts.IsNotNullOrEmpty(name, "name");
            Asserts.IsNotNegative(price, price.ToString());
            Asserts.IsNotNegative(quantity, quantity.ToString());
            
            Name = name;
            Price = price;
            Quantity = quantity;
            Id = id;
        }
    }
}
