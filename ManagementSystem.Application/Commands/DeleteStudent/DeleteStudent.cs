using ManagementSystem.Application.Dtos.DeleteStudent;
using ManagementSystem.Domain.Repositories.Interfaces;

namespace ManagementSystem.Application.Commands.DeleteStudent;

public class DeleteStudent : IDeleteStudent
{
    private readonly IStudentReadOnlyRepository _studentReadOnlyRepository;
    private readonly IStudentWriteOnlyRepository _studentWriteOnlyRepository;

    public DeleteStudent(IStudentReadOnlyRepository studentReadOnlyRepository, IStudentWriteOnlyRepository studentWriteOnlyRepository)
    {
        _studentReadOnlyRepository = studentReadOnlyRepository;
        _studentWriteOnlyRepository = studentWriteOnlyRepository;
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
            return new DeleteStudentFailed();
        }
    }
}
