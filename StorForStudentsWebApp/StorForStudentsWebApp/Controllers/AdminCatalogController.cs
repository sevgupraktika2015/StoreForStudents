using System.Linq;
using System.Web.Mvc;
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
                ViewBag.Items = repository.GetAll();
            }
            return View();
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
