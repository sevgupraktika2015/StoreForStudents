using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.Entities;

namespace Implementation.Mappings
{
    class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Orders");
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.UserId).HasColumnName("User");
        }
    }
}
