using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class BillOfMaterialsBomConfiguration : IEntityTypeConfiguration<BillOfMaterialsBom>
    {
        public void Configure(EntityTypeBuilder<BillOfMaterialsBom> entity)
        {
            entity.HasKey(e => e.Bomid);

            entity.HasOne(e => e.Product).WithMany(p => p.BillOfMaterialsBoms)
                  .HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.RawMaterial).WithMany(r => r.BillOfMaterialsBomRawMaterials)
                  .HasForeignKey(e => e.RawMaterialId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.SubstituteRawMaterial).WithMany(r => r.BillOfMaterialsBomSubstituteRawMaterials)
                  .HasForeignKey(e => e.SubstituteRawMaterialId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}