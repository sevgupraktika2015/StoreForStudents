﻿using System.Collections.Generic;
using DomainLogic.Entities;

namespace DomainLogic.Repositories
{
    /// <summary>
    /// Repository for Items
    /// </summary>
    public interface IItemsRepository
    {
        /// <summary>
        /// Returns item by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Item GetById(int id);

        List<Item> GetAll();
    }
}
