using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using Implementation.Repositories;
using StorForStudentsWebApp.Models;

namespace StorForStudentsWebApp.Controllers
{
    public class ViewOrderController : Controller
    {
        //
        // GET: /ViewOrder/
        public ActionResult Index()
        {
            return View();
        }
	}
}