using ManagementSystem.Application.Dtos.UpdateTeacher;
using ManagementSystem.Application.Extensions;
using ManagementSystem.Domain.Repositories.Interfaces;

namespace ManagementSystem.Application.Commands.UpdateTeacher;

public class UpdateTeacher : IUpdateTeacher
{
    private readonly ITeacherReadOnlyRepository _teacherReadOnlyRepository;
    private readonly ITeacherWriteOnlyRepository _teacherWriteOnlyRepository;

    public UpdateTeacher(ITeacherReadOnlyRepository teacherReadOnlyRepository, ITeacherWriteOnlyRepository teacherWriteOnlyRepository)
    {
        _teacherReadOnlyRepository = teacherReadOnlyRepository;
        _teacherWriteOnlyRepository = teacherWriteOnlyRepository;
    }

    public async Task<UpdateTeacherResult> Execute(UpdateTeacherCommand dto)
    {
        try
        {
            var teacherExists = await _teacherReadOnlyRepository.Exists(dto.Id);

            if (!teacherExists)
                return new UpdateTeacherNotFound();

            var teacher = dto.ToDomain();

            await _teacherWriteOnlyRepository.Update(teacher);
            return new UpdateTeacherSuccess();
        }
        catch (Exception)
        {
            return new UpdateTeacherFailed();
        }
    }
}
