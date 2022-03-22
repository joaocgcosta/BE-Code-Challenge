using MediatR;

namespace MED.MedicationManagement.Application.Features.Medications.Requests.Commands
{
    public class DeleteMedicationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
