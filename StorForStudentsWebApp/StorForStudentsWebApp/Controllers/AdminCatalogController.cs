using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
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
            using (var context = new StoreDbContext())
            {
                ItemsRepository repository = new ItemsRepository(context);
                ViewBag.Items = repository.EntitySet.ToArray();
            }
            return View(db.Items.ToList());
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
