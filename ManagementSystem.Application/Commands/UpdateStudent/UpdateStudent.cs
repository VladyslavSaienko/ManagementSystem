using ManagementSystem.Application.Dtos.Results.UpdateStudent;
using ManagementSystem.Application.Extensions;
using ManagementSystem.Domain.Repositories.Interfaces;

namespace ManagementSystem.Application.Commands.UpdateStudent;

public class UpdateStudent : IUpdateStudent
{
    private readonly IStudentReadOnlyRepository _studentReadOnlyRepository;
    private readonly IStudentWriteOnlyRepository _studentWriteOnlyRepository;

    public UpdateStudent(IStudentReadOnlyRepository studentReadOnlyRepository, IStudentWriteOnlyRepository studentWriteOnlyRepository)
    {
        _studentReadOnlyRepository = studentReadOnlyRepository;
        _studentWriteOnlyRepository = studentWriteOnlyRepository;
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
        catch (Exception)
        {
            return new UpdateStudentFailed();
        }
    }
}
