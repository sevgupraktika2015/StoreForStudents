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
            using (var context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                IList<Item> itemResult = repository.GetAll();
            }
            return View();
        }

        //
        // POST: /AddItem/Create
        [HttpPost]
        public ActionResult Create(ItemModel initem)
        {
            try
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
                return View(new ItemModel(outitem));
                //AdminCatalogController Admin = new AdminCatalogController();
                //return Admin.Index();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AddItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /AddItem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AddItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AddItem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
