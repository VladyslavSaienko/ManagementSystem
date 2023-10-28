using ManagementSystem.Application.Dtos.Results.AddTeacher;
using ManagementSystem.Application.Extensions;
using ManagementSystem.Domain.Repositories.Interfaces;

namespace ManagementSystem.Application.Commands.AddTeacher;

public class AddTeacher : IAddTeacher
{
    private readonly ITeacherWriteOnlyRepository _teacherWriteOnlyRepository;

    public AddTeacher(ITeacherWriteOnlyRepository teacherWriteOnlyRepository)
    {
        _teacherWriteOnlyRepository = teacherWriteOnlyRepository;
    }

    public async Task<AddTeacherResult> Execute(AddTeacherCommand dto)
    {
        try
        {
            var teacher = dto.ToDomain();

            await _teacherWriteOnlyRepository.Add(teacher);
            return new AddTeacherSuccess(teacher.Id);
        }
        catch (Exception)
        {
            return new AddTeacherFailed();
        }
    }
}
