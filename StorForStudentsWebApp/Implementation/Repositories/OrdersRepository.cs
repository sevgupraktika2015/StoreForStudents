﻿using System;
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
    public class OrdersRepository : IOrdersReporitory
    {
        protected readonly DbContext DbContext;
        protected DbSet<Order> EntitySet { get; set; }

        public OrdersRepository(DbContext dbContext)
        {
            Asserts.IsNotNull(dbContext, "dbContext");
            DbContext = dbContext;
            EntitySet = dbContext.Set<Order>();
        }

        public Order GetById(int id)
        {
            Order current = EntitySet.Find(id);
            return current;
        }

        public List<Order> GetByUserId(int userid)
        {
            List<Order> current = EntitySet.Where(s => s.User == userid).ToList();
            return current;
        }
    }
}
