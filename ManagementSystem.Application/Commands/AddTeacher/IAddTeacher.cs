using ManagementSystem.Application.Dtos.AddTeacher;

namespace ManagementSystem.Application.Commands.AddTeacher;

public interface IAddTeacher
{
    Task<AddTeacherResult> Execute(AddTeacherCommand dto);
}
