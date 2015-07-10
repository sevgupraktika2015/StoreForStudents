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
        public string User { set; get; }
        public Order()
        {
            //entity fw usage
        }

        public Order(string userid = "", int orderid = 0) : base(orderid)
        {
            Asserts.IsNotNullOrEmpty(userid);
            User = userid;
        } 
    }
}
