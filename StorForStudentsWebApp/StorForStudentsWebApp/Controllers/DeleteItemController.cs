using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DomainLogic.Entities;
using Implementation.Repositories;
using StorForStudentsWebApp.Models;
using DomainLogic.Utilities;

namespace StorForStudentsWebApp.Controllers
{
    public class DeleteItemController : Controller
    {
        //
        // GET: /DeleteItem/
        public ActionResult Index(ItemModel inItem)
        {
            Asserts.IsNotNull(inItem);
            // TODO: Add insert logic here
            using (var context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                Item delItem;
                delItem = repository.GetById(inItem.Id);
                repository.DeleteItem(delItem);
            }
            return RedirectToAction("Index", "AdminCatalog");
        }
    }
}
