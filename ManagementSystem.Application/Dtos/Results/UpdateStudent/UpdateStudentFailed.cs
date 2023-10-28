namespace ManagementSystem.Application.Dtos.Results.UpdateStudent;

public record UpdateStudentFailed(string Message = "Failed to delete student")
    : UpdateStudentResult;
