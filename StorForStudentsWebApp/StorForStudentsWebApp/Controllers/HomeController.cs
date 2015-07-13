using System.Net;
using System.Web.Mvc;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using Implementation.Repositories;
using System.Linq;
using StorForStudentsWebApp.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace StorForStudentsWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Index() 
        {
            using (StoreDbContext context = new StoreDbContext ()) {
                IItemsRepository repository = new ItemsRepository (context);
                IList<Item> items = repository.GetAll ();
                List<ItemModel> itemsDTO = new List<ItemModel> ();
                foreach (Item element in items) {
                    itemsDTO.Add (new ItemModel (element));
                }
                return View (itemsDTO);
            }
        }
    }
}