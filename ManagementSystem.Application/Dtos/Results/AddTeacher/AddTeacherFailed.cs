namespace ManagementSystem.Application.Dtos.Results.AddTeacher;

public record AddTeacherFailed(string Message = "Adding Teacher failed.")
    : AddTeacherResult;
