using System.Threading;
using System.Threading.Tasks;
using MED.MedicationManagement.Application.Contracts.Persistence;
using MED.MedicationManagement.Application.Exceptions;
using MED.MedicationManagement.Application.Features.Medications.Requests.Commands;
using MED.MedicationManagement.Domain;
using MediatR;

namespace MED.MedicationManagement.Application.Features.Medications.Handlers.Commands
{
    public class DeleteMedicationCommandHandler : IRequestHandler<DeleteMedicationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMedicationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteMedicationCommand request, CancellationToken cancellationToken)
        {
            var medication = await _unitOfWork.MedicationRepository.GetAsync(request.Id);

            if (medication == null)
                throw new NotFoundException(nameof(Medication), request.Id);

            await _unitOfWork.MedicationRepository.Delete(medication);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
