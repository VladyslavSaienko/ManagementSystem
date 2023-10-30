using ManagementSystem.Application.Dtos.Results.AddStudent;
using ManagementSystem.Application.Extensions;
using ManagementSystem.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ManagementSystem.Application.Commands.AddStudent;

public class AddStudent : IAddStudent
{
    private readonly IStudentWriteOnlyRepository _studentWriteOnlyRepository;
    private readonly ILogger<AddStudent> _logger;

    public AddStudent(IStudentWriteOnlyRepository studentWriteOnlyRepository, ILogger<AddStudent> logger)
    {
        _studentWriteOnlyRepository = studentWriteOnlyRepository;
        _logger = logger;
    }

    public async Task<AddStudentResult> Execute(AddStudentCommand dto)
    {
        try
        {
            var student = dto.ToDomain();

            await _studentWriteOnlyRepository.Add(student);
            return new AddStudentSuccess(student.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred during adding new student.");
            return new AddStudentFailed();
        }
    }
}
