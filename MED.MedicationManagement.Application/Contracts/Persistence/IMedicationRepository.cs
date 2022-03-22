using MED.MedicationManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MED.MedicationManagement.Application.Contracts.Persistence
{
    public interface IMedicationRepository : IGenericRepository<Medication>
    {
        Task<Medication> GetMedicationWithDetails(int id);
        Task<List<Medication>> GetMedicationsWithDetails();
    }
}
