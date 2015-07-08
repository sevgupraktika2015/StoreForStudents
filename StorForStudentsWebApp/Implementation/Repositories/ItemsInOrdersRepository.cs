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
    class ItemsInOrdersRepository : IItemsInOrdersRepository
    {
        protected readonly DbContext DbContext;
        protected DbSet<ItemsInOrder> EntitySet { get; set; }

        ItemsInOrdersRepository(DbContext dbContext)
        {
            Asserts.IsNotNull(dbContext, "dbContext");
            DbContext = dbContext;
            EntitySet = dbContext.Set<ItemsInOrder>();
        }
    }
}
