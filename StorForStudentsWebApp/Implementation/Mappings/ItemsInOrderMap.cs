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
            ToTable("ItemsInOrder");
            Property(x => x.OrderId).HasColumnName("IdOrder");
            Property(x => x.ItemId).HasColumnName("IdItem");
            Property(x => x.Quantity).HasColumnName("Quantity");
        }
    }
}
