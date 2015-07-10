using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.User).HasColumnName("User");
            HasMany(x => x.Items).WithRequired(x => x.Order).HasForeignKey(x => x.Id);
        }
    }
}
