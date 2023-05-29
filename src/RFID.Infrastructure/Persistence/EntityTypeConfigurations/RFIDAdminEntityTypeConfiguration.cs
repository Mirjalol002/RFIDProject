using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFID.Domain.Entities;

namespace RFID.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class RFIDAdminEntityTypeConfiguration : IEntityTypeConfiguration<RFIDAdmin>
    {
        public void Configure(EntityTypeBuilder<RFIDAdmin> builder)
        {
            builder.ToTable("Admin");
        }
    }
}
