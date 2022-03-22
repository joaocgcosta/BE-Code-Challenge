using MED.MedicationManagement.Application.DTOs.Common;
using System;

namespace MED.MedicationManagement.Application.DTOs.Medication
{
    public class MedicationDto : BaseDto
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
