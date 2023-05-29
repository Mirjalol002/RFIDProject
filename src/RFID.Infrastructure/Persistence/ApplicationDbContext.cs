using Microsoft.EntityFrameworkCore;
using RFID.Application.Abstractions;
using RFID.Domain.Entities;

namespace RFID.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<RFIDAdmin> RFIDAdmins { get; set; }
        public DbSet<RFIDUser> RFIDUsers { get; set; }
        public DbSet<RFIDModel> RFIDModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
