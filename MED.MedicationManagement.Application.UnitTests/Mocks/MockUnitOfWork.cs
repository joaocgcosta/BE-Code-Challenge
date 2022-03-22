using MED.MedicationManagement.Application.Contracts.Persistence;
using Moq;

namespace MED.MedicationManagement.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockMedicationRepo = MockMedicationRepository.GetMedicationRepository();

            mockUow.Setup(r => r.MedicationRepository).Returns(mockMedicationRepo.Object);

            return mockUow;
        }
    }
}
