namespace ManagementSystem.Application.Commands.UpdateStudent;

public record UpdateStudentCommand(
    Guid Id,
    string NationalIdNumber,
    string Name,
    string Surname,
    string Number,
    DateOnly DateOfBirth);
