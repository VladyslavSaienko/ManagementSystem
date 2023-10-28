using ManagementSystem.Application.Dtos.UpdateStudent;

namespace ManagementSystem.Application.Commands.UpdateStudent;

public interface IUpdateStudent
{
    Task<UpdateStudentResult> Execute(UpdateStudentCommand dto);
}
