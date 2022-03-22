using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MED.MedicationManagement.Application.Contracts.Persistence;
using MED.MedicationManagement.Application.DTOs.Medication;
using MED.MedicationManagement.Application.Features.Medications.Handlers.Commands;
using MED.MedicationManagement.Application.Features.Medications.Requests.Commands;
using MED.MedicationManagement.Application.Profiles;
using MED.MedicationManagement.Application.Responses;
using MED.MedicationManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace MED.MedicationManagement.Application.UnitTests.Medication.Commands
{
    public class CreateMedicationCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateMedicationDto _medicationDto;
        private readonly CreateMedicationCommandHandler _handler;

        public CreateMedicationCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateMedicationCommandHandler(_mockUow.Object, _mapper);

            _medicationDto = new CreateMedicationDto
            {
                Quantity = 5,
                Name = "Rennie"
            };
        }

        [Fact]
        public async Task CreateMedicationCommand_WithValidMedication_ShouldAddNewMedication()
        {
            // Act & Assert
            var result = await _handler.Handle(new CreateMedicationCommand() { MedicationDto = _medicationDto }, CancellationToken.None);

            var medications = await _mockUow.Object.MedicationRepository.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();
            medications.Count.ShouldBe(4);
        }

        [Fact]
        public async Task CreateMedicationCommand_WithZeroQuantity_ShouldNotAddNewMedication()
        {
            // Arrange
            _medicationDto.Quantity = 0;
            
            // Act & Assert
            var result = await _handler.Handle(new CreateMedicationCommand() { MedicationDto = _medicationDto }, CancellationToken.None);

            var medications = await _mockUow.Object.MedicationRepository.GetAllAsync();
            
            medications.Count.ShouldBe(3);
            result.ShouldBeOfType<BaseCommandResponse>();
        }
    }
}
