using Microsoft.AspNet.Identity.EntityFramework;
using DomainLogic.Entities;

namespace StorForStudentsWebApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<DomainLogic.Entities.Item> Items { get; set; }

        public System.Data.Entity.DbSet<StorForStudentsWebApp.Models.ItemModel> ItemModels { get; set; }

        public System.Data.Entity.DbSet<StorForStudentsWebApp.Models.OrderModel> OrderModels { get; set; }
    }
}