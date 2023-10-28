namespace ManagementSystem.Application.Dtos.AddTeacher;

public record AddTeacherFailed(string Message = "Adding Teacher failed.") 
    : AddTeacherResult;
