namespace ManagementSystem.Application.Dtos.Results.ListStudents;

public record ListStudentsFailed(string Message = "Loading students failed")
    : ListStudentsResult;
