namespace ManagementSystem.Application.Commands.AddStudent;

public record AddStudentCommand(
    string NationalIdNumber,
    string Name,
    string Surname,
    string Number,
    DateOnly DateOfBirth);
