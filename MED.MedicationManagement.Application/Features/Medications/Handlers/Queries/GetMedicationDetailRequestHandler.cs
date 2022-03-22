using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MED.MedicationManagement.Application.Contracts.Persistence;
using MED.MedicationManagement.Application.DTOs.Medication;
using MED.MedicationManagement.Application.Features.Medications.Requests.Queries;
using MediatR;

namespace MED.MedicationManagement.Application.Features.Medications.Handlers.Queries
{
    using MED.MedicationManagement.Application.Exceptions;
    using MED.MedicationManagement.Domain;

    public class GetMedicationDetailRequestHandler : IRequestHandler<GetMedicationDetailRequest, MedicationDto>
    {
        private readonly IMedicationRepository _medicationRepository;
        private readonly IMapper _mapper;

        public GetMedicationDetailRequestHandler(IMedicationRepository medicationRepository,
            IMapper mapper)
        {
            _medicationRepository = medicationRepository;
            _mapper = mapper;
        }
        public async Task<MedicationDto> Handle(GetMedicationDetailRequest request, CancellationToken cancellationToken)
        {
            var medication = _mapper.Map<MedicationDto>(await _medicationRepository.GetMedicationWithDetails(request.Id));
            if (medication == null)
                throw new NotFoundException(nameof(Medication), request.Id);
            return medication;
        }
    }
}
