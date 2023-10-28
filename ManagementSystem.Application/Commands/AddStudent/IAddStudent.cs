using ManagementSystem.Application.Dtos.Results.AddStudent;

namespace ManagementSystem.Application.Commands.AddStudent;

public interface IAddStudent
{
    Task<AddStudentResult> Execute(AddStudentCommand dto);
}
