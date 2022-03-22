using FluentValidation;

namespace MED.MedicationManagement.Application.DTOs.Medication.Validators
{
    public class MedicationDtoValidator : AbstractValidator<IMedicationDto>
    {
        public MedicationDtoValidator( )
        {
            RuleFor(p => p.Quantity)
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than zero.");
        }
    }
}
