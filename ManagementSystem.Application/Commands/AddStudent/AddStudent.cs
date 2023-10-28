using ManagementSystem.Application.Dtos.AddStudent;
using ManagementSystem.Application.Extensions;
using ManagementSystem.Domain.Repositories.Interfaces;

namespace ManagementSystem.Application.Commands.AddStudent;

public class AddStudent : IAddStudent
{
    private readonly IStudentWriteOnlyRepository _studentWriteOnlyRepository;

    public AddStudent(IStudentWriteOnlyRepository studentWriteOnlyRepository)
    {
        _studentWriteOnlyRepository = studentWriteOnlyRepository;
    }

    public async Task<AddStudentResult> Execute(AddStudentCommand dto)
    {
        try
        {
            var student = dto.ToDomain();

            await _studentWriteOnlyRepository.Add(student);
            return new AddStudentSuccess(student.Id);
        }
        catch (Exception)
        {
            return new AddStudentFailed();
        }
    }
}
