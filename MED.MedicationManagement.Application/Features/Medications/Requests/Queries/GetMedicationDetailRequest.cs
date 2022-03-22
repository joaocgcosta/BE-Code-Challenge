using MED.MedicationManagement.Application.DTOs.Medication;
using MediatR;

namespace MED.MedicationManagement.Application.Features.Medications.Requests.Queries
{
    public class GetMedicationDetailRequest : IRequest<MedicationDto>
    {
        public int Id { get; set; }
    }
}
