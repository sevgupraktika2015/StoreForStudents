using System.Web;
using System.Web.Mvc;
using Implementation.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using StorForStudentsWebApp.Models;

namespace StorForStudentsWebApp.Controllers
{
    public class BucketPartialController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public BucketPartialController() 
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        { }

        public BucketPartialController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public int GetItemsCountInOrder()
        {
            int itemsCount = 0;
            var userId = AuthenticationManager.User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                var ordersRepository = new OrdersRepository(context);
                var itemsInOrderRepository = new ItemsInOrdersRepository(context);
                //TODO: подсчет количества товаров
            }
            return itemsCount;
        }

        public decimal GetOrderPrice()
        {
            decimal orderPrice = 0;
            var userId = AuthenticationManager.User.Identity.GetUserId();
            //TODO: подсчет общей цены
            return orderPrice;
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}