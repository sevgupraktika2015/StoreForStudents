using System.Data.Entity.ModelConfiguration;
using DomainLogic.Entities;

namespace Implementation.Mappings
{
    /// <summary>
    /// Mapping for Items
    /// </summary>
    /// 
    class MapItem : EntityTypeConfiguration<Item>
    {
        public MapItem()
        {
            ToTable("Items");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("ItemName");
            Property(x => x.Price).HasColumnName("PriceAmount");
            Property(x => x.Quantity).HasColumnName("Quantity");
            Property(x => x.ImagePath).HasColumnName("ImagePath");
            Property(x => x.Description).HasColumnName("Description");
        }

    }
}
