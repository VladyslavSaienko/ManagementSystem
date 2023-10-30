using FluentValidation;
using ManagementSystem.Application.Commands.UpdateTeacher;
using ManagementSystem.Domain.Enums;

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

        RuleFor(a => (Title)Enum.Parse(typeof(Title), a.Title))
            .IsInEnum()
            .WithMessage(FluentValidationMessages.NotValidTeacherTitleMessage);
    }
}
