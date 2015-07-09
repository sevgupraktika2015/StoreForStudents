using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                var ordersRepository = new OrdersRepository(context);
                var itemsInOrderRepository = new ItemsInOrdersRepository(context);
                var itemsRepository = new ItemsRepository(context);
                List<Order> orders = ordersRepository.FindByUser(id);
                foreach (var order in orders)
                {
                    List<ItemsInOrder> itemsInOrder = itemsInOrderRepository.Find(order.Id);
                    List<OrderItem> items = new List<OrderItem>();
                    foreach (var itemInOrder in itemsInOrder)
                    {
                        items.Add(new OrderItem(itemsRepository.GetById(itemInOrder.ItemId), itemInOrder.Quantity));
                    }
                    orderDto.Add(new OrderModel(order, items));
                }
            }
            return View(orderDto);
        }
	}
}