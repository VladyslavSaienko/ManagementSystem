namespace ManagementSystem.Application.Dtos.DeleteTeacher;

public record DeleteTeacherFailed(string Message = "Failed to delete teacher") 
    : DeleteTeacherResult;

