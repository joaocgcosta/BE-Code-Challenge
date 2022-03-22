using MED.MedicationManagement.Application.DTOs.Common;

namespace MED.MedicationManagement.Application.DTOs.Medication
{
    public class MedicationListDto : BaseDto
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
    }
}
