namespace ManagementSystem.Application.Dtos.Results.GetStudent;

public record GetStudentNotFound(string Message = "Student for which this action was invoked was not found in the database.")
    :GetStudentResult;
