using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Xsl;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using Implementation.Repositories;
using StorForStudentsWebApp.Models;

namespace StorForStudentsWebApp.Controllers
{
    public class ViewOrderController : Controller
    {
        //
        // GET: /ViewOrder/
        public ActionResult Index(int? userid)
        
        {
            int id = 0;
            if (userid != null)
            {
                id = userid.Value;
            }
            List<OrderModel> orderDto = new List<OrderModel>();
            using (var context = new StoreDbContext())
            {
                IOrdersReporitory ordersRepository = new OrdersRepository(context);
                IItemsRepository itemsRepository = new ItemsRepository(context);
                List<Order> orders = ordersRepository.GetByUserId(id);
                List<Item> items = itemsRepository.GetAll();
                foreach (var order in orders)
                {
                    orderDto.Add(new OrderModel(order, items));
                } 
            }
            return View(orderDto);
        }

        public ActionResult Details(OrderModel  order)
        {
            return View(order);
        }
	}
}