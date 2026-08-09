using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class BatchTrackTraceConfiguration : IEntityTypeConfiguration<BatchTrackTrace>
    {
        public void Configure(EntityTypeBuilder<BatchTrackTrace> entity)
        {
            entity.HasKey(e => e.TraceId);

            entity.HasOne(e => e.Product).WithMany(p => p.BatchTrackTraces).HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.ProductionOrder).WithMany(p => p.BatchTrackTraces).HasForeignKey(e => e.ProductionOrderId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.RawMaterial).WithMany(r => r.BatchTrackTraces).HasForeignKey(e => e.RawMaterialId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Supplier).WithMany(s => s.BatchTrackTraces).HasForeignKey(e => e.SupplierId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Qclog).WithMany(q => q.BatchTrackTraces).HasForeignKey(e => e.QclogId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.WarehouseInventory).WithMany(w => w.BatchTrackTraces).HasForeignKey(e => e.WarehouseInventoryId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.SalesOrder).WithMany(s => s.BatchTrackTraces).HasForeignKey(e => e.SalesOrderId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Shipment).WithMany(s => s.BatchTrackTraces).HasForeignKey(e => e.ShipmentId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Customer).WithMany(c => c.BatchTrackTraces).HasForeignKey(e => e.CustomerId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Stamp).WithMany(s => s.BatchTrackTraces).HasForeignKey(e => e.StampId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}