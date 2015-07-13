using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.Utilities;

namespace DomainLogic.Entities
{
    public class Order : BaseEntity
    {
        public int User { set; get; }
        public virtual ICollection<ItemsInOrder> Items { get; set; }
        public Order()
        {
            Items = new List<ItemsInOrder>();
            //entity fw usage
        }

        public Order(int userid = 0, int orderid = 0) : base(orderid)
        {
            Asserts.IsNotNegative(userid);
            User = userid;
            Items = new List<ItemsInOrder>();
        }
        public Order(List<ItemsInOrder> items, int userid = 0, int orderid = 0)
            : base(orderid)
        {
            Asserts.IsNotNegative(userid);
            Asserts.IsNotNull(items);
            User = userid;
            Items = items;
        } 
    }
}
