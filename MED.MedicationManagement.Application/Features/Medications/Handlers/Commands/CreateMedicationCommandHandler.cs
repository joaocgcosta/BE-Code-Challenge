using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MED.MedicationManagement.Application.Contracts.Persistence;
using MED.MedicationManagement.Application.DTOs.Medication.Validators;
using MED.MedicationManagement.Application.Features.Medications.Requests.Commands;
using MED.MedicationManagement.Application.Responses;
using MED.MedicationManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MED.MedicationManagement.Application.Features.Medications.Handlers.Commands
{

    public class CreateMedicationCommandHandler : IRequestHandler<CreateMedicationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMedicationCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMedicationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMedicationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MedicationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Request Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var medication = _mapper.Map<Medication>(request.MedicationDto);
                medication = await _unitOfWork.MedicationRepository.AddAsync(medication);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Medication Created Successfully";
                response.Id = medication.Id;
            }
            
            return response;
        }
    }
}
