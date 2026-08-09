using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class QualityControlLogConfiguration : IEntityTypeConfiguration<QualityControlLog>
    {
        public void Configure(EntityTypeBuilder<QualityControlLog> entity)
        {
            entity.HasKey(e => e.Qcid);

            entity.HasOne(e => e.ProductionOrder).WithMany(p => p.QualityControlLogs)
                  .HasForeignKey(e => e.ProductionOrderId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Product).WithMany(p => p.QualityControlLogs)
                  .HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.RawMaterial).WithMany(r => r.QualityControlLogs)
                  .HasForeignKey(e => e.RawMaterialId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}