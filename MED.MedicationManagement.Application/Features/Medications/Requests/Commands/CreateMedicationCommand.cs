using MED.MedicationManagement.Application.DTOs.Medication;
using MED.MedicationManagement.Application.Responses;
using MediatR;

namespace MED.MedicationManagement.Application.Features.Medications.Requests.Commands
{
    public class CreateMedicationCommand : IRequest<BaseCommandResponse>
    {
        public CreateMedicationDto MedicationDto { get; set; }
    }
}
