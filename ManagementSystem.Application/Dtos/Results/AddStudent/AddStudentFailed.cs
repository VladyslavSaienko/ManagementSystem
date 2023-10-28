namespace ManagementSystem.Application.Dtos.Results.AddStudent;

public record AddStudentFailed(string Message = "Adding Student failed.")
    : AddStudentResult;
