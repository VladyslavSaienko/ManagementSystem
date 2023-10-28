namespace ManagementSystem.Application.Dtos.Requests;

public record SearchStudents(
    int Page = 1,
    int ItemsPerPage = 10);
