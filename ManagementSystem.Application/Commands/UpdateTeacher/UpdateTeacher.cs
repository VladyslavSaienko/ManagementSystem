using ManagementSystem.Application.Dtos.Results.UpdateTeacher;
using ManagementSystem.Application.Extensions;
using ManagementSystem.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ManagementSystem.Application.Commands.UpdateTeacher;

public class UpdateTeacher : IUpdateTeacher
{
    private readonly ITeacherReadOnlyRepository _teacherReadOnlyRepository;
    private readonly ITeacherWriteOnlyRepository _teacherWriteOnlyRepository;
    private readonly ILogger<UpdateTeacher> _logger;

    public UpdateTeacher(ITeacherReadOnlyRepository teacherReadOnlyRepository, ITeacherWriteOnlyRepository teacherWriteOnlyRepository, ILogger<UpdateTeacher> logger)
    {
        _teacherReadOnlyRepository = teacherReadOnlyRepository;
        _teacherWriteOnlyRepository = teacherWriteOnlyRepository;
        _logger = logger;
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred during update teacher.");
            return new UpdateTeacherFailed();
        }
    }
}
