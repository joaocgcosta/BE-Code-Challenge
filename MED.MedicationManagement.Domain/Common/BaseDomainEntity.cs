using System;

namespace MED.MedicationManagement.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
