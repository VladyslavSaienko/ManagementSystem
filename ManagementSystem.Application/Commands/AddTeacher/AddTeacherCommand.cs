using ManagementSystem.Domain.Enums;

namespace ManagementSystem.Application.Commands.AddTeacher;

public record AddTeacherCommand(
    string NationalIdNumber,
    string Name,
    string Surname,
    string Number,
    DateOnly DateOfBirth,
    string Title,
    int? Salary);

