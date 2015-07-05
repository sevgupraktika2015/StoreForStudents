﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DomainLogic.Entities;
using DomainLogic.Repositories;
using DomainLogic.Utilities;

namespace Implementation.Repositories {
    /// <summary>
    /// Repository for Items of the store
    /// </summary>
    public class ItemsRepository : IItemsRepository {
        /// <summary>
        /// Context of database
        /// </summary>
        protected readonly DbContext DbContext;

        /// <summary>
        /// List of entities (table from DB)
        /// </summary>
        private DbSet<Item> EntitySet { get;  set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public ItemsRepository (DbContext dbContext) {
            Asserts.IsNotNull (dbContext, "dbContext");
            DbContext = dbContext;
            EntitySet = dbContext.Set<Item> ();
        }

        public void SaveItem (Item item) {
            EntitySet.Add (item);
            DbContext.SaveChanges ();
        }

        public void DeleteItem(Item delitem)
        {
            foreach (var item in EntitySet)
            {
                if (Equals(item, delitem) == true)
                    EntitySet.Remove(delitem);
            }
        }

        public void DeleteAll () {
            foreach (var item in EntitySet) {
                EntitySet.Remove (item);
            }
        }
        public List<Item> GetAll()
        {
            List<Item> ilist = EntitySet.ToList();
            return ilist;
        }

        public List<Item> Find(string searchString)
        {
            List<Item> ilist =  new List<Item>();
            if (!String.IsNullOrEmpty(searchString))
                ilist = EntitySet.Where(s => s.Name.Contains(searchString)).ToList();
            return ilist;
        }

        /// <summary>
        /// Returns item by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Item GetById (int id) {
            return EntitySet.Find (id);
        }
    }
}