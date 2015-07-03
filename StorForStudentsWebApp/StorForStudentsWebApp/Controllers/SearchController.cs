using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainLogic.Repositories;
using Implementation.Repositories;
using StorForStudentsWebApp.Models;

namespace StorForStudentsWebApp.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        public ActionResult Index(string searchString)
        {
            var itemsDbo = new List<ItemModel>();
            IItemsRepository repository;
            using (var context = new StoreDbContext())
                if (!String.IsNullOrEmpty(searchString))
                {
                    repository = new ItemsRepository(context);
                    var items = repository.GetAll();
                    itemsDbo.AddRange(items.Select(item => new ItemModel(item)));
                    itemsDbo = itemsDbo.Where(s => s.Name.Contains(searchString)).ToList();
                }
                else
                {
                    repository = new ItemsRepository(context);
                    var items = repository.GetById(1);
                    itemsDbo.Add(new ItemModel(items));
                }
            return View(itemsDbo);
        }
	}
}