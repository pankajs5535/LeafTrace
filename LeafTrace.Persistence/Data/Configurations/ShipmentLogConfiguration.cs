using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class ShipmentLogConfiguration : IEntityTypeConfiguration<ShipmentLog>
    {
        public void Configure(EntityTypeBuilder<ShipmentLog> entity)
        {
            entity.HasKey(e => e.ShipmentId);

            entity.HasOne(e => e.SalesOrder).WithMany(s => s.ShipmentLogs)
                  .HasForeignKey(e => e.SalesOrderId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.PickPack).WithMany(p => p.ShipmentLogs)
                  .HasForeignKey(e => e.PickPackId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
