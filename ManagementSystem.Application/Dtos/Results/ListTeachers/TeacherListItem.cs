using ManagementSystem.Domain.Enums;

namespace ManagementSystem.Application.Dtos.Results.ListTeachers;

public record TeacherListItem(
    Guid Id,
    string NationalIdNumber,
    string Name,
    string Surname,
    string Number,
    DateOnly DateOfBirth,
    Title Title,
    int? Salary);
