using FluentValidation;

namespace MED.MedicationManagement.Application.DTOs.Medication.Validators
{
    public class CreateMedicationDtoValidator : AbstractValidator<CreateMedicationDto>
    {

        public CreateMedicationDtoValidator()
        {
            Include(new MedicationDtoValidator());
        }
    }
}
