using ManagementSystem.Application.Dtos.Results.AddTeacher;
using ManagementSystem.Application.Extensions;
using ManagementSystem.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ManagementSystem.Application.Commands.AddTeacher;

public class AddTeacher : IAddTeacher
{
    private readonly ITeacherWriteOnlyRepository _teacherWriteOnlyRepository;
    private readonly ILogger<AddTeacher> _logger;

    public AddTeacher(ITeacherWriteOnlyRepository teacherWriteOnlyRepository, ILogger<AddTeacher> logger)
    {
        _teacherWriteOnlyRepository = teacherWriteOnlyRepository;
        _logger = logger;
    }

    public async Task<AddTeacherResult> Execute(AddTeacherCommand dto)
    {
        try
        {
            var teacher = dto.ToDomain();

            await _teacherWriteOnlyRepository.Add(teacher);
            return new AddTeacherSuccess(teacher.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred during adding new teacher.");
            return new AddTeacherFailed();
        }
    }
}
