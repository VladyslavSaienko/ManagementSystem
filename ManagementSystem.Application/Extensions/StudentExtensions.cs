using ManagementSystem.Application.Commands.AddStudent;
using ManagementSystem.Application.Commands.UpdateStudent;
using ManagementSystem.Domain.Models;

namespace ManagementSystem.Application.Extensions;

internal static class StudentExtensions
{
    public static Student ToDomain(this AddStudentCommand command)
    {
        return new Student(
            Guid.NewGuid(),
            command.NationalIdNumber,
            command.Name,
            command.Surname,
            command.DateOfBirth,
            command.Number);
    }

    public static Student ToDomain(this UpdateStudentCommand command)
    {
        return new Student(
            command.Id,
            command.NationalIdNumber,
            command.Name,
            command.Surname,
            command.DateOfBirth,
            command.Number);
    }
}
