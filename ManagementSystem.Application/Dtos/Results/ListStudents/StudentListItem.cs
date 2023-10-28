namespace ManagementSystem.Application.Dtos.Results.ListStudents;

public record StudentListItem(
    Guid Id,
    string NationalIdNumber,
    string Name,
    string Surname,
    string Number,
    DateOnly DateOfBirth);
