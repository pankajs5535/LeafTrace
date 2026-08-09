using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class RawMaterialConfiguration : IEntityTypeConfiguration<RawMaterial>
    {
        public void Configure(EntityTypeBuilder<RawMaterial> entity)
        {
            entity.HasKey(e => e.RawMaterialId);

            entity.HasOne(e => e.PrimarySupplier)
                  .WithMany(s => s.RawMaterials)
                  .HasForeignKey(e => e.PrimarySupplierId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}