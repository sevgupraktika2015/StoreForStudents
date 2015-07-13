using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Implementation.Repositories;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using DomainLogic.Utilities;
using StorForStudentsWebApp.Models;

namespace StorForStudentsWebApp.Controllers
{
    public class AddItemController : Controller
    {
        // GET: /AddItem/
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /AddItem/Create
        [HttpPost]
        public ActionResult Create(ItemModel initem)
        {
            Asserts.IsNotNull(initem);
            Item outitem;
            // TODO: Add insert logic here
            using (var context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                outitem = initem.ConvertToItem();
                repository.SaveItem(outitem);
            }
            return RedirectToAction("Index", "AdminCatalog");
        }
    }
}
