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
        public ActionResult Index()
        {
            OrdersRepository ordersRepository;
            ItemsInOrdersRepository itemsInOrderRepository;
            ItemsRepository itemsRepository;
            OrderModel orderDto;
            using (var context = new StoreDbContext())
            {
                ordersRepository = new OrdersRepository(context);
                itemsInOrderRepository = new ItemsInOrdersRepository(context);
                itemsRepository = new ItemsRepository(context);
                Order order = ordersRepository.Find(1);
                List<ItemsInOrder> itemsInOrder = itemsInOrderRepository.Find(1);
                List<OrderItem> items = new List<OrderItem>();
                foreach (var itemInOrder in itemsInOrder)
                {
                   items.Add(new OrderItem(itemsRepository.GetById(itemInOrder.ItemId), itemInOrder.Quantity)); 
                }
                orderDto = new OrderModel(order.Id, order.User, items);
            }
            return View(orderDto);
        }
	}
}