using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class ExciseStampConfiguration : IEntityTypeConfiguration<ExciseStamp>
    {
        public void Configure(EntityTypeBuilder<ExciseStamp> entity)
        {
            entity.HasKey(e => e.StampId);

            entity.HasOne(e => e.Product).WithMany(p => p.ExciseStamps)
                  .HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.AppliedToProductionOrder).WithMany(p => p.ExciseStamps)
                  .HasForeignKey(e => e.AppliedToProductionOrderId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.StorageLocationBin).WithMany(b => b.ExciseStamps)
                  .HasForeignKey(e => e.StorageLocationBinId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}