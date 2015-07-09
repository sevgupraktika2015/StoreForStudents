using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.Entities;

namespace DomainLogic.Repositories
{
    public interface IItemsInOrdersRepository
    {
        List<Entities.ItemsInOrder> Find(int id);
    }
}
