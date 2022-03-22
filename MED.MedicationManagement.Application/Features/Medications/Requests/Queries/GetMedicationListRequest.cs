using MED.MedicationManagement.Application.DTOs.Medication;
using MediatR;
using System.Collections.Generic;

namespace MED.MedicationManagement.Application.Features.Medications.Requests.Queries
{
    public class GetMedicationListRequest : IRequest<List<MedicationListDto>>
    {
    }
}
