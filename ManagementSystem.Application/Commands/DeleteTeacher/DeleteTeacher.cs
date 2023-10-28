using ManagementSystem.Application.Dtos.DeleteTeacher;
using ManagementSystem.Domain.Repositories.Interfaces;

namespace ManagementSystem.Application.Commands.DeleteTeacher;

public class DeleteTeacher : IDeleteTeacher
{
    private readonly ITeacherReadOnlyRepository _teacherReadOnlyRepository;
    private readonly ITeacherWriteOnlyRepository _teacherWriteOnlyRepository;

    public DeleteTeacher(ITeacherReadOnlyRepository teacherReadOnlyRepository, ITeacherWriteOnlyRepository teacherWriteOnlyRepository)
    {
        _teacherReadOnlyRepository = teacherReadOnlyRepository;
        _teacherWriteOnlyRepository = teacherWriteOnlyRepository;
    }

    public async Task<DeleteTeacherResult> Execute(Guid teacherId)
    {
        var teacherExists = await _teacherReadOnlyRepository.Exists(teacherId);
        if (!teacherExists)
            return new DeleteTeacherNotFound();

        try
        {
            await _teacherWriteOnlyRepository.Delete(teacherId);
            return new DeleteTeacherSuccess();
        }
        catch (Exception ex)
        {
            return new DeleteTeacherFailed();
        }
    }
}
