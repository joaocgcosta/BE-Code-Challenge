using MED.MedicationManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MED.MedicationManagement.Persistence.Repositories
{
    using MED.MedicationManagement.Domain;

    public class MedicationRepository : GenericRepository<Medication>, IMedicationRepository
    {
        private readonly MedicationManagementDbContext _dbContext;

        public MedicationRepository(MedicationManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Medication>> GetMedicationsWithDetails()
        {
            var medications = await _dbContext.Medications
                .ToListAsync();
            
            return medications;
        }

        public async Task<Medication> GetMedicationWithDetails(int id)
        {
            var medication = await _dbContext.Medications
                .FirstOrDefaultAsync(q => q.Id == id);

            return medication;
        }
    }
}
