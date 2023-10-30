using ManagementSystem.Application.Dtos.Results.UpdateStudent;
using ManagementSystem.Application.Extensions;
using ManagementSystem.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ManagementSystem.Application.Commands.UpdateStudent;

public class UpdateStudent : IUpdateStudent
{
    private readonly IStudentReadOnlyRepository _studentReadOnlyRepository;
    private readonly IStudentWriteOnlyRepository _studentWriteOnlyRepository;
    private readonly ILogger<UpdateStudent> _logger;

    public UpdateStudent(IStudentReadOnlyRepository studentReadOnlyRepository, IStudentWriteOnlyRepository studentWriteOnlyRepository, ILogger<UpdateStudent> logger)
    {
        _studentReadOnlyRepository = studentReadOnlyRepository;
        _studentWriteOnlyRepository = studentWriteOnlyRepository;
        _logger = logger;
    }

    public async Task<UpdateStudentResult> Execute(UpdateStudentCommand dto)
    {
        try
        {
            var studentExists = await _studentReadOnlyRepository.Exists(dto.Id);
            if (!studentExists)
                return new UpdateStudentNotFound();

            var student = dto.ToDomain();

            await _studentWriteOnlyRepository.Update(student);
            return new UpdateStudentSuccess();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred during update student.");
            return new UpdateStudentFailed();
        }
    }
}
