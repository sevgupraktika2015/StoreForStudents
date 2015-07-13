using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.Entities;

namespace Implementation.Mappings
{
    class ItemsInOrderMap : EntityTypeConfiguration<ItemsInOrder>
    {
        public ItemsInOrderMap()
        {
            ToTable("ItemsInOrders");
            Property(x => x.Id).HasColumnName("IdItem");
            Property(x => x.OrderId).HasColumnName("IdOrder");
            Property(x => x.Quantity).HasColumnName("Quantity");
            HasRequired(x => x.Order).WithMany(s => s.Items).HasForeignKey(x => x.OrderId);
        }
    }
}
