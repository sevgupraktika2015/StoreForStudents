using System.Collections.Generic;
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

<<<<<<< HEAD
        void SaveItem(Item item);
=======
        List<Item> GetAll();
        List<Item> Find(string searchString);
        void SaveItem(Item item);
        void DeleteItem(Item delitem);
        void DeleteAll();
>>>>>>> 2ee61362fbad26461b177adf714e4f070c5a296c
    }
}
