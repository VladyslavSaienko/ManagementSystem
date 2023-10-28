namespace ManagementSystem.Application.Dtos.Results.GetStudent;

public record GetStudentSuccess(
    Guid Id,
    string NationalIdNumber,
    string Name,
    string Surname,
    string Number,
    DateOnly DateOfBirth) : GetStudentResult;
