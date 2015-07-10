using DomainLogic.Entities;
using System.Collections.Generic;

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
        void AddItem(Item item);
        void DeleteAll();
        void SaveItem(Item item);
        void DeleteItem(Item delitem);
        List<Item> GetAll();
        List<Item> Find(string searchString);

        List<Item> GetViewItems(List<ItemsInOrder> itemsInOrders);
    }
}
