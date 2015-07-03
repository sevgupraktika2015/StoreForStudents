using System.Data.Entity;
using System.Data.Entity.Migrations;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using DomainLogic.Utilities;

namespace Implementation.Repositories
{
    /// <summary>
    /// Repository for Items of the store
    /// </summary>
    public class ItemsRepository : IItemsRepository
    {
        /// <summary>
        /// Context of database
        /// </summary>
        protected readonly DbContext DbContext;

        /// <summary>
        /// List of entities (table from DB)
        /// </summary>
        public DbSet<Item> EntitySet { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public ItemsRepository(DbContext dbContext)
        {
            Asserts.IsNotNull(dbContext, "dbContext");
            DbContext = dbContext;
            EntitySet = dbContext.Set<Item>();
        }

        /// <summary>
        /// Returns item by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Item GetById(int id)
        {
            return EntitySet.Find(id);
        }
        public void AddItem(Item item)
        {
            EntitySet.AddOrUpdate(item);
            DbContext.SaveChanges();
        }
    }
}
