using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StorForStudentsWebApp.Models;

namespace StorForStudentsWebApp.Controllers
{
    public class BucketController : Controller
    {
        public ActionResult Index()
        {
            var model = new BucketViewModel();
            return View(model);
        }
    }
}