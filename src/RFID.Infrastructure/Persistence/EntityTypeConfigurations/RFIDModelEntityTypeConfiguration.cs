using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFID.Domain.Entities;

namespace RFID.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class RFIDModelEntityTypeConfiguration : IEntityTypeConfiguration<RFIDModel>
    {
        public void Configure(EntityTypeBuilder<RFIDModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<RFIDUser>(x => x.RFIDUser)
                .WithOne(p => p.Model)
                .HasForeignKey<RFIDUser>(p => p.RFIDModelId);
        }
    }
}