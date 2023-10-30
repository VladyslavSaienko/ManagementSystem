using FluentValidation;
using ManagementSystem.Application.Commands.UpdateTeacher;

namespace ManagementSystem.WebApi.Validators;

public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
{
    public UpdateTeacherCommandValidator()
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
            .Must(a => DateOnly.FromDateTime(DateTime.Now) > a.AddYears(21))
            .WithMessage(FluentValidationMessages.NotValidTeacherAgeMessage);

        RuleFor(a => a.Number)
            .NotEmpty()
            .WithMessage(FluentValidationMessages.NotEmptyMessage);

        RuleFor(a => a.Title)
            .IsInEnum()
            .WithMessage(FluentValidationMessages.NotValidTeacherTitleMessage);
    }
}
