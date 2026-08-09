using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class ProductionOrderConfiguration : IEntityTypeConfiguration<ProductionOrder>
    {
        public void Configure(EntityTypeBuilder<ProductionOrder> entity)
        {
            entity.HasKey(e => e.ProductionOrderId);

            entity.HasOne(e => e.Product).WithMany(p => p.ProductionOrders)
                  .HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Bom).WithMany(b => b.ProductionOrders)
                  .HasForeignKey(e => e.Bomid).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Machine).WithMany(m => m.ProductionOrders)
                  .HasForeignKey(e => e.MachineId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}