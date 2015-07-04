using System.Data.Entity;
using Implementation.Mappings;


namespace Implementation.Repositories
{
    /// <summary>
    /// Context for store database
    /// </summary>
    public class StoreDbContext : DbContext
    {
        public StoreDbContext()
            : base("StoreDBConnection")
        {
            Database.SetInitializer<StoreDbContext>(null); // stop database creation if not exists. Create DB manually
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapItem());
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<DomainLogic.Entities.Item> Items { get; set; }
    }
}
