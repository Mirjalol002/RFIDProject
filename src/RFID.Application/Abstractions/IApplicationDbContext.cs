using Microsoft.EntityFrameworkCore;
using RFID.Domain.Entities;

namespace RFID.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<RFIDAdmin> RFIDAdmins { get; set; }
        DbSet<RFIDUser> RFIDUsers { get; set; }
        DbSet<RFIDModel> RFIDModels { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
