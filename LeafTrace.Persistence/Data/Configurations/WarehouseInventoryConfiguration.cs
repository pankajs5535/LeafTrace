using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class WarehouseInventoryConfiguration : IEntityTypeConfiguration<WarehouseInventory>
    {
        public void Configure(EntityTypeBuilder<WarehouseInventory> entity)
        {
            entity.HasKey(e => e.InventoryId);

            entity.HasOne(e => e.Bin).WithMany(b => b.WarehouseInventories)
                  .HasForeignKey(e => e.BinId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Product).WithMany(p => p.WarehouseInventories)
                  .HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.RawMaterial).WithMany(r => r.WarehouseInventories)
                  .HasForeignKey(e => e.RawMaterialId).OnDelete(DeleteBehavior.Restrict);

            entity.Property(x => x.TotalValue).HasPrecision(18, 2);
            entity.Property(x => x.UnitCost).HasPrecision(18, 2);
            entity.Property(x => x.VarianceQty).HasPrecision(18, 2);
        }
    }
}