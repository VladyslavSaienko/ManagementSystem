using ManagementSystem.Application.Dtos.AddStudent;

namespace ManagementSystem.Application.Commands.AddStudent;

public interface IAddStudent
{
    Task<AddStudentResult> Execute(AddStudentCommand dto);
}
