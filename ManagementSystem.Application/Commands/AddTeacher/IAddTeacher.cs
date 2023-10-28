using ManagementSystem.Application.Dtos.Results.AddTeacher;

namespace ManagementSystem.Application.Commands.AddTeacher;

public interface IAddTeacher
{
    Task<AddTeacherResult> Execute(AddTeacherCommand dto);
}
