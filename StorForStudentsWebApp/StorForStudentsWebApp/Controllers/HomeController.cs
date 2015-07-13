using System.Net;
using System.Web.Mvc;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using Implementation.Repositories;
using System.Linq;
using StorForStudentsWebApp.Models;
using System.Data.Entity;

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
            using (var context = new StoreDbContext()) 
            {
                ItemsRepository repository = new ItemsRepository(context);
                //ViewBag.Items = repository.EntitySet.ToList ();
            }
            return View ();
        }
    }
}