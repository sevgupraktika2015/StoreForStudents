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
            IList<ItemModel> itemList;
            using (var context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                ViewBag.Items = repository.GetAll().ToList();
                itemList = ItemModel.ToModel(repository.GetAll());
            }
            return View(itemList);
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
