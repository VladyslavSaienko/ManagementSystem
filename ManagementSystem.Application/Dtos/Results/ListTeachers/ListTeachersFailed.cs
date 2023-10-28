namespace ManagementSystem.Application.Dtos.Results.ListTeachers;

public record ListTeachersFailed(string Message = "Loading teachers failed")
    : ListTeachersResult;
