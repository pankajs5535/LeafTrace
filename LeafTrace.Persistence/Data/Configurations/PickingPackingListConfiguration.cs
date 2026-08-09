using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class PickingPackingListConfiguration : IEntityTypeConfiguration<PickingPackingList>
    {
        public void Configure(EntityTypeBuilder<PickingPackingList> entity)
        {
            entity.HasKey(e => e.PickPackId);

            entity.HasOne(e => e.SalesOrder).WithMany(s => s.PickingPackingLists)
                  .HasForeignKey(e => e.SalesOrderId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Product).WithMany(p => p.PickingPackingLists)
                  .HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Bin).WithMany(b => b.PickingPackingLists)
                  .HasForeignKey(e => e.BinId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}