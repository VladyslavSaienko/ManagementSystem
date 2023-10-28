namespace ManagementSystem.Application.Dtos.AddStudent;

public record AddStudentFailed(string Message = "Adding Student failed.") 
    : AddStudentResult;
