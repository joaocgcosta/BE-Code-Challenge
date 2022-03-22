using MED.MedicationManagement.Domain.Common;

namespace MED.MedicationManagement.Domain
{
    public class Medication : BaseDomainEntity
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
    }
}
