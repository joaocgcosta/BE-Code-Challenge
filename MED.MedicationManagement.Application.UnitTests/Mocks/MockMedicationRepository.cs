using MED.MedicationManagement.Application.Contracts.Persistence;
using Moq;
using System.Collections.Generic;

namespace MED.MedicationManagement.Application.UnitTests.Mocks
{
    using Medication = MED.MedicationManagement.Domain.Medication;

    public static class MockMedicationRepository
    {
        public static Mock<IMedicationRepository> GetMedicationRepository()
        {
            var medications = new List<Medication>
            {
                new Medication
                {
                    Id = 1,
                    Quantity = 10,
                    Name = "Proton"
                },
                new Medication
                {
                    Id = 2,
                    Quantity = 15,
                    Name = "Gaviscon"
                },
                new Medication
                {
                    Id = 3,
                    Quantity = 15,
                    Name = "Sedoxil"
                }
            };

            var mockRepo = new Mock<IMedicationRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(medications);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Medication>())).ReturnsAsync((Medication medication) => 
            {
                medications.Add(medication);
                return medication;
            });

            return mockRepo;
        }
    }
}

