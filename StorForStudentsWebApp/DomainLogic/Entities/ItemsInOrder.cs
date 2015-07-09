using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.Utilities;

namespace DomainLogic.Entities
{
    public class ItemsInOrder : BaseEntity
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public ItemsInOrder()
        {
            // entity fw usage only
        }

        public ItemsInOrder(int orderid, int itemid, int quantity) : base(orderid)
        {
            Asserts.IsNotNegative(itemid);
            Asserts.IsNotNegative(quantity);
            ItemId = itemid;
            Quantity = quantity;
        }  
    }
}
