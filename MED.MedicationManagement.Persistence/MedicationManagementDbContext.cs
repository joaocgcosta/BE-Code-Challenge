using MED.MedicationManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace MED.MedicationManagement.Persistence
{

    public class MedicationManagementDbContext : AuditableDbContext
    {
        public MedicationManagementDbContext(DbContextOptions<MedicationManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedicationManagementDbContext).Assembly);
        }

        public DbSet<Medication> Medications { get; set; }
    }
}
