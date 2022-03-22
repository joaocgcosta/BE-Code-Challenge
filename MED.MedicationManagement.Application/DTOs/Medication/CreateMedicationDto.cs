namespace MED.MedicationManagement.Application.DTOs.Medication
{
    public class CreateMedicationDto : IMedicationDto
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
    }
}
