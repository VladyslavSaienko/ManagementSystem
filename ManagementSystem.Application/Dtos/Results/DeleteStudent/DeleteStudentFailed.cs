namespace ManagementSystem.Application.Dtos.Results.DeleteStudent;

public record DeleteStudentFailed(string Message = "Failed to delete student")
    : DeleteStudentResult;
