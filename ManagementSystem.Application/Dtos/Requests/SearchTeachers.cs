namespace ManagementSystem.Application.Dtos.Requests;

public record SearchTeachers(
    int Page = 1,
    int ItemsPerPage = 10);
