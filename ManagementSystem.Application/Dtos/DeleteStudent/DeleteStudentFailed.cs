namespace ManagementSystem.Application.Dtos.DeleteStudent;

public record DeleteStudentFailed(string Message = "Failed to delete student") 
    : DeleteStudentResult;
