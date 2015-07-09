using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StorForStudentsWebApp.Controllers
{
    public class BucketPartialController : Controller
    {
        public int GetItemsCountInOrder()
        {
            int itemsCount = 0;
            //TODO: подсчет количества предметов
            return itemsCount;
        }

        public decimal GetOrderPrice()
        {
            decimal orderPrice = 0;
            //TODO: подсчет общей цены
            return orderPrice;
        }
    }
}