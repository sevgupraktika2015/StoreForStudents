using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.Utilities;

namespace DomainLogic.Entities
{
    public class ItemsInOrder 
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public ItemsInOrder()
        {
            // entity fw usage only
        }

        public ItemsInOrder(int orderid, int itemid, int quantity)
        {
            Asserts.IsNotNegative(orderid);
            Asserts.IsNotNegative(itemid);
            Asserts.IsNotNegative(quantity);
            OrderId = orderid;
            ItemId = itemid;
            Quantity = quantity;
        }  
    }
}
