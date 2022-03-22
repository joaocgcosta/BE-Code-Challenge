using System;
using System.Threading.Tasks;

namespace MED.MedicationManagement.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IMedicationRepository MedicationRepository { get; }
        Task Save();
    }
}
