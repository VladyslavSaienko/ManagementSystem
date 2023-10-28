using ManagementSystem.Application.Dtos.Results.UpdateStudent;

namespace ManagementSystem.Application.Commands.UpdateStudent;

public interface IUpdateStudent
{
    Task<UpdateStudentResult> Execute(UpdateStudentCommand dto);
}
