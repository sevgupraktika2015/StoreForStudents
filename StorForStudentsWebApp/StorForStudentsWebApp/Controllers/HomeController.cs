using System.Net;
using System.Web.Mvc;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using Implementation.Repositories;
using StorForStudentsWebApp.Models;

namespace StorForStudentsWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (StoreDbContext context = new StoreDbContext())
            {
                IItemsRepository repository = new ItemsRepository(context);
                Item item = repository.GetById(1);
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