using FluentValidation;
using ManagementSystem.Application.Commands.AddStudent;

namespace ManagementSystem.WebApi.Validators;

public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
{
    public AddStudentCommandValidator()
    {
        RuleFor(a => a.NationalIdNumber)
            .NotEmpty()
            .WithMessage(FluentValidationMessages.NotEmptyMessage);

        RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage(FluentValidationMessages.NotEmptyMessage);

        RuleFor(a => a.Surname)
            .NotEmpty()
            .WithMessage(FluentValidationMessages.NotEmptyMessage);

        RuleFor(a => a.DateOfBirth)
            .NotEmpty()
            .WithMessage(FluentValidationMessages.NotEmptyMessage);

        RuleFor(a => a.DateOfBirth)
            .Must(a => DateOnly.FromDateTime(DateTime.Now) < a.AddYears(22))
            .WithMessage(FluentValidationMessages.NotValidStudentAgeMessage);

        RuleFor(a => a.Number)
            .NotEmpty()
            .WithMessage(FluentValidationMessages.NotEmptyMessage);
    }
}
