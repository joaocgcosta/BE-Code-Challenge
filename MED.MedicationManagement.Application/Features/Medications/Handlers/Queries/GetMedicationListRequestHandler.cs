using MED.MedicationManagement.Application.Contracts.Persistence;
using MED.MedicationManagement.Application.DTOs.Medication;
using MED.MedicationManagement.Application.Features.Medications.Requests.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace MED.MedicationManagement.Application.Features.Medications.Handlers.Queries
{

    public class GetMedicationListRequestHandler : IRequestHandler<GetMedicationListRequest, List<MedicationListDto>>
    {
        private readonly IMedicationRepository _medicationRepository;
        private readonly IMapper _mapper;

        public GetMedicationListRequestHandler(IMedicationRepository medicationRepository,
            IMapper mapper)
        {
            _medicationRepository = medicationRepository;
            _mapper = mapper;
        }

        public async Task<List<MedicationListDto>> Handle(GetMedicationListRequest request, CancellationToken cancellationToken)
        {
            var medications = await _medicationRepository.GetMedicationsWithDetails();
            var medicationListDtos = _mapper.Map<List<MedicationListDto>>(medications);

            return medicationListDtos;
        }
    }
}
