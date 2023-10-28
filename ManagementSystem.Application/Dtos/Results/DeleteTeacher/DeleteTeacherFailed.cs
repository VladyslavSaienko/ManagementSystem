namespace ManagementSystem.Application.Dtos.Results.DeleteTeacher; 

public record DeleteTeacherFailed(string Message = "Failed to delete teacher") 
    : DeleteTeacherResult;

