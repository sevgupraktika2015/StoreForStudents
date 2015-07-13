using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DomainLogic.Entities;
using Implementation.Repositories;
using StorForStudentsWebApp.Models;
using DomainLogic.Repositories;
using System.Net;

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
                itemList = ItemModel.ToModel(repository.GetAll());
            }
            return View("Index", new AdminCatalogViewModel(itemList));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                Item item = repository.GetById(id);
                if (item == null)
                {
                    return RedirectToAction("Index");
                }
                ItemModel itemDTO = new ItemModel(item);
                return View(itemDTO);
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                Item item = repository.GetById(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                ItemModel itemDBO = new ItemModel(item);
                return View(itemDBO);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemModel itemDBO)
        {
            if (ModelState.IsValid)
            {
                using (StoreDbContext context = new StoreDbContext())
                {
                    IItemsRepository repository = new ItemsRepository(context);
                    Item item = new Item();
                    item = itemDBO.ConvertToItem();
                    repository.AddItem(item);
                    return RedirectToAction("Index");
                }
            }
            return View(itemDBO);
        }
    }
}
