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
        public List<ItemsInOrder> Items { get; set; }
        public Order()
        {
            //entity fw usage
        }

        public Order(int userid = 0, int orderid = 0) : base(orderid)
        {
            Asserts.IsNotNegative(userid);
            User = userid;
        } 
    }
}
