using ManagementSystem.Application.Dtos.Results.DeleteTeacher;
using ManagementSystem.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ManagementSystem.Application.Commands.DeleteTeacher;

public class DeleteTeacher : IDeleteTeacher
{
    private readonly ITeacherReadOnlyRepository _teacherReadOnlyRepository;
    private readonly ITeacherWriteOnlyRepository _teacherWriteOnlyRepository;
    private readonly ILogger<DeleteTeacher> _logger;

    public DeleteTeacher(ITeacherReadOnlyRepository teacherReadOnlyRepository, ITeacherWriteOnlyRepository teacherWriteOnlyRepository, ILogger<DeleteTeacher> logger)
    {
        _teacherReadOnlyRepository = teacherReadOnlyRepository;
        _teacherWriteOnlyRepository = teacherWriteOnlyRepository;
        _logger = logger;
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
            _logger.LogError(ex, "Error occurred during delete teacher.");
            return new DeleteTeacherFailed();
        }
    }
}
