using ManagementSystem.Application.Dtos.Results.DeleteStudent;
using ManagementSystem.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ManagementSystem.Application.Commands.DeleteStudent;

public class DeleteStudent : IDeleteStudent
{
    private readonly IStudentReadOnlyRepository _studentReadOnlyRepository;
    private readonly IStudentWriteOnlyRepository _studentWriteOnlyRepository;
    private readonly ILogger<DeleteStudent> _logger;

    public DeleteStudent(IStudentReadOnlyRepository studentReadOnlyRepository, IStudentWriteOnlyRepository studentWriteOnlyRepository, ILogger<DeleteStudent> logger)
    {
        _studentReadOnlyRepository = studentReadOnlyRepository;
        _studentWriteOnlyRepository = studentWriteOnlyRepository;
        _logger = logger;
    }

    public async Task<DeleteStudentResult> Execute(Guid studentId)
    {
        var studentExists = await _studentReadOnlyRepository.Exists(studentId);
        if (!studentExists)
            return new DeleteStudentNotFound();

        try
        {
            await _studentWriteOnlyRepository.Delete(studentId);
            return new DeleteStudentSuccess();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred during delete student.");
            return new DeleteStudentFailed();
        }
    }
}
