using ManagementSystem.Domain.Enums;

namespace ManagementSystem.Application.Dtos.Results.GetTeacher;

public record GetTeacherSuccess(
    Guid Id,
    string NationalIdNumber,
    string Name,
    string Surname,
    string Number,
    DateOnly DateOfBirth,
    Title Title,
    int? Salary) : GetTeacherResult;
