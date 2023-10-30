using ManagementSystem.Domain.Enums;

namespace ManagementSystem.Application.Dtos.Results.GetTeacher;

public record GetTeacherSuccess(
    Guid Id,
    string NationalIdNumber,
    string Name,
    string Surname,
    string Number,
    DateOnly DateOfBirth,
    string Title,
    int? Salary) : GetTeacherResult;
