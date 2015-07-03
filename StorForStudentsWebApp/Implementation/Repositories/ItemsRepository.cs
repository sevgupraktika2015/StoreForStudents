﻿using System.Data.Entity;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using DomainLogic.Utilities;
using System.Collections.Generic;
using System.Linq;

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

        public List<Item> GetAll()
        {
            List<Item> ilist = EntitySet.ToList();
            return ilist;
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
    }
}
