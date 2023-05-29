using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFID.Domain.Entities;

namespace RFID.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class RFIDUserEntityTypeConfiguration : IEntityTypeConfiguration<RFIDUser>
    {
        public void Configure(EntityTypeBuilder<RFIDUser> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}