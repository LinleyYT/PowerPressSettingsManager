using System.Data;
using FluentValidation;
using PowerPressSettingsManager.DTOs;

namespace PowerPressSettingsManager.Validator
{
    public class CreatePressSettingDtoValidator : AbstractValidator<CreatePressSettingDto>
    {
        public CreatePressSettingDtoValidator() { 
            RuleFor(x => x.PartNumber)
                .NotEmpty().WithMessage("Part number is required.")
                .Length(16).WithMessage("Part number must be 16 characters.");

            RuleFor(x => x.ClampingHight).NotEmpty().WithMessage("Clamping height is required.")
                .GreaterThan(0).WithMessage("Clamping height must be greater than 0.")
                .LessThan(30).WithMessage("Clamping height must be less than 30.");
        }
    }
}
