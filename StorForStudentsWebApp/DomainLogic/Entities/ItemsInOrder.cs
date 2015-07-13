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
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public ItemsInOrder()
        {
            // entity fw usage only
        }

        public ItemsInOrder(int orderid, int itemid, int quantity) : base(itemid)
        {
            Asserts.IsNotNegative(itemid);
            Asserts.IsNotNegative(quantity);
            OrderId = orderid;
            Quantity = quantity;
        }  
    }
}
