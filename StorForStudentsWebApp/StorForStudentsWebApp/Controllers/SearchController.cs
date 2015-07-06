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
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        public ActionResult Index(string searchString)
        {
            List<ItemModel> itemsDto = new List<ItemModel>();
            ItemsRepository repository;
            using (var context = new StoreDbContext())
                if (!String.IsNullOrEmpty(searchString))
                {
                    repository = new ItemsRepository(context);
                    List<Item> items = repository.Find(searchString);
                    foreach (var item in items)
                    {
                        itemsDto.Add(new ItemModel(item));
                    }
                }
            return View(itemsDto);
        }
	}
}