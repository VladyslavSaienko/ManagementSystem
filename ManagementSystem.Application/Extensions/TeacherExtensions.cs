using ManagementSystem.Application.Commands.AddTeacher;
using ManagementSystem.Application.Commands.UpdateTeacher;
using ManagementSystem.Domain.Models;

namespace ManagementSystem.Application.Extensions;

internal static class TeacherExtensions
{
    public static Teacher ToDomain(this AddTeacherCommand command)
    {
        return new Teacher(
            Guid.NewGuid(),
            command.NationalIdNumber,
            command.Name,
            command.Surname,
            command.DateOfBirth,
            command.Title,
            command.Number,
            command.Salary);
    }

    public static Teacher ToDomain(this UpdateTeacherCommand command)
    {
        return new Teacher(
            command.Id,
            command.NationalIdNumber,
            command.Name,
            command.Surname,
            command.DateOfBirth,
            command.Title,
            command.Number,
            command.Salary);
    }
}
