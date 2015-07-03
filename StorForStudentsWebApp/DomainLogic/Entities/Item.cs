using DomainLogic.Utilities;

namespace DomainLogic.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Item()
        {
            // for Entity Framework usage only
        }

        public Item(string name, decimal price, int quantity, int id = 0): base(id)
        {
            Asserts.IsNotNullOrEmpty(name, "name");
            Asserts.IsNotNegative(price, price.ToString());
            Asserts.IsNotNegative(quantity, quantity.ToString());
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
