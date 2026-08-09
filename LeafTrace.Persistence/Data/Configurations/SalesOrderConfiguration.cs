using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> entity)
        {
            entity.HasKey(e => e.SalesOrderId);

            entity.HasOne(e => e.Customer).WithMany(c => c.SalesOrders)
                  .HasForeignKey(e => e.CustomerId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Product).WithMany(p => p.SalesOrders)
                  .HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}