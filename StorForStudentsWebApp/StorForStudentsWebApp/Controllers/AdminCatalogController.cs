using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DomainLogic.Entities;
using Implementation.Repositories;
using StorForStudentsWebApp.Models;

namespace StorForStudentsWebApp.Controllers
{
    public class AdminCatalogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminCatalog
        public ActionResult Index()
        {
            IList<Item> itemList;
            using (var context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
<<<<<<< HEAD
                ViewBag.Items = repository.EntitySet.ToList();
                itemList = repository; //TODO: items list
=======
                ViewBag.Items = repository.GetAll();
>>>>>>> bc27918494b1ff20355b90f71c6c5532ce53d0dc
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
