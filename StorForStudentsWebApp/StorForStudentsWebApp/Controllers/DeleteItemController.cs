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
            try
            {
                Asserts.IsNotNull(inItem);
                // TODO: Add insert logic here
                using (var context = new StoreDbContext())
                {
                    ItemsRepository repository = new ItemsRepository(context);
                    Asserts.IsNotNull(repository.Find(inItem.ConvertToItem().Name));
                    repository.DeleteItem(inItem.ConvertToItem());
                }
                return RedirectToAction("Index", "AdminCatalog");
            }
            catch
            {
                return RedirectToAction("Index", "AdminCatalog");
            }
        }

        //
        // GET: /DeleteItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /DeleteItem/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DeleteItem/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /DeleteItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /DeleteItem/Edit/5
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
        // GET: /DeleteItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /DeleteItem/Delete/5
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
