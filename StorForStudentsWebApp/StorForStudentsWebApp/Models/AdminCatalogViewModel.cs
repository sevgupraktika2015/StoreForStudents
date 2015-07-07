using System.Collections;
using System.Collections.Generic;
using DomainLogic.Entities;

namespace StorForStudentsWebApp.Models
{
    public class AdminCatalogViewModel
    {
        public IList<ItemModel> itemList { get; protected set; }

        public AdminCatalogViewModel(IList<Item> list)
        {
            itemList = ItemModel.ToModel(list);
        }

        public AdminCatalogViewModel(IList<ItemModel> list)
        {
            itemList = list;
        }
    }
}