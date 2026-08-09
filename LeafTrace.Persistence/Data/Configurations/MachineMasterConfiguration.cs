using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LeafTrace.Domain.Entities;

namespace LeafTrace.Persistence.Data.Configurations
{
    public class MachineMasterConfiguration : IEntityTypeConfiguration<MachineMaster>
    {
        public void Configure(EntityTypeBuilder<MachineMaster> entity)
        {
            entity.HasKey(e => e.MachineId);
        }
    }
}