using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Repositories
{
    public interface IOrdersReporitory
    {
        Entities.Order GetById(int id);

        List<Entities.Order> GetByUserId(int id);
    }
}
