using DomainLogic.Entities;
using DomainLogic.Utilities;
using Implementation.Repositories;
using StorForStudentsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                delItem = inItem.ConvertToItem();
                repository.DeleteItem(delItem);
            }
            return RedirectToAction("Index", "AdminCatalog");
        }
    }
}
