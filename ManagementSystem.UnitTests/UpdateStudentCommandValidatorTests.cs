using FluentValidation.TestHelper;
using ManagementSystem.Application.Commands.UpdateStudent;
using ManagementSystem.WebApi.Validators;
using NUnit.Framework;

namespace ManagementSystem.UnitTests;

[TestFixture]
internal class UpdateStudentCommandValidatorTests
{
    private UpdateStudentCommandValidator _validator;

    private static UpdateStudentCommand CreateValidModel =>
        new(
            Guid.NewGuid(),
            "ID12345",
            "John",
            "Doe",
            "TJ8",
            new DateOnly(2004, 4, 15)
            );

    [SetUp]
    public void SetUp()
    {
        _validator = new UpdateStudentCommandValidator();
    }

    [Test]
    public async Task WhenValidModel_ThenShouldNotHaveAnyValidationErrors()
    {
        var cmd = CreateValidModel;
        var result = await _validator.TestValidateAsync(cmd);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Test]
    public async Task WhenInvalidModelWithNameMissing_ThenValidatorErrorIsReturned()
    {
        var cmd = CreateValidModel with { Name = string.Empty };
        var result = await _validator.TestValidateAsync(cmd);
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    [Test]
    public async Task WhenInvalidModelWithSurnameMissing_ThenValidatorErrorIsReturned()
    {
        var cmd = CreateValidModel with { Surname = string.Empty };
        var result = await _validator.TestValidateAsync(cmd);
        result.ShouldHaveValidationErrorFor(p => p.Surname);
    }

    [Test]
    public async Task WhenInvalidModelWithNationalIdMissing_ThenValidatorErrorIsReturned()
    {
        var cmd = CreateValidModel with { NationalIdNumber = string.Empty };
        var result = await _validator.TestValidateAsync(cmd);
        result.ShouldHaveValidationErrorFor(p => p.NationalIdNumber);
    }

    [Test]
    public async Task WhenInvalidModelWithStudentNumberMissing_ThenValidatorErrorIsReturned()
    {
        var cmd = CreateValidModel with { Number = string.Empty };
        var result = await _validator.TestValidateAsync(cmd);
        result.ShouldHaveValidationErrorFor(p => p.Number);
    }

    [Test]
    public async Task WhenInvalidModelWithInvalidDateOfBirth_ThenValidatorErrorIsReturned()
    {
        var cmd = CreateValidModel with { DateOfBirth = new DateOnly(1995, 1, 5) };
        var result = await _validator.TestValidateAsync(cmd);
        result.ShouldHaveValidationErrorFor(p => p.DateOfBirth);
    }
}
