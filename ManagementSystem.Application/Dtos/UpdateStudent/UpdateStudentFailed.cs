namespace ManagementSystem.Application.Dtos.UpdateStudent;

public record UpdateStudentFailed(string Message = "Failed to delete student") 
    : UpdateStudentResult;
