using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Entities
{
    public class OrderItem
    {
        public Item Item;
        public int Quantity;

        public OrderItem(Item item, ItemsInOrder order)
        {
            Item = item;
            Quantity = order.Id;
        }
    }
}
