using ManagementSystem.Domain.Models;

namespace ManagementSystem.Domain.Repositories.Results.Students;

public record StudentFoundResult(Student Student) : GetStudentResult;
