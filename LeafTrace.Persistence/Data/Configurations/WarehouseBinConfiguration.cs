using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class WarehouseBinConfiguration : IEntityTypeConfiguration<WarehouseBin>
    {
        public void Configure(EntityTypeBuilder<WarehouseBin> entity)
        {
            entity.HasKey(e => e.BinId);
        }
    }
}