using MED.MedicationManagement.Application.Contracts.Persistence;
using System;
using System.Threading.Tasks;

namespace MED.MedicationManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MedicationManagementDbContext _context;
        private IMedicationRepository _medicationRepository;


        public UnitOfWork(MedicationManagementDbContext context)
        {
            _context = context;
        }
        
        public IMedicationRepository MedicationRepository => 
            _medicationRepository ??= new MedicationRepository(_context);
        
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save() 
        {
            await _context.SaveChangesAsync();
        }
    }
}
