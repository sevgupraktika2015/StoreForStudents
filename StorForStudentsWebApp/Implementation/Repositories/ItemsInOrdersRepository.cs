using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using DomainLogic.Utilities;

namespace Implementation.Repositories
{
    public class ItemsInOrdersRepository : IItemsInOrdersRepository
    {
        protected readonly DbContext DbContext;
        protected DbSet<ItemsInOrder> EntitySet { get; set; }

        public ItemsInOrdersRepository(DbContext dbContext)
        {
            Asserts.IsNotNull(dbContext, "dbContext");
            DbContext = dbContext;
            EntitySet = dbContext.Set<ItemsInOrder>();
        }

        public List<ItemsInOrder> Find(int id)
        {
            List<ItemsInOrder> outlist = EntitySet.Where(s => s.ItemId == id).ToList();
            return outlist;

        }
    }
}
