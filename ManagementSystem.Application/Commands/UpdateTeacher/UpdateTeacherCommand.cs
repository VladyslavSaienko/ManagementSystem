﻿using ManagementSystem.Domain.Enums;

namespace ManagementSystem.Application.Commands.UpdateTeacher;

public record UpdateTeacherCommand(
    Guid Id,
    string NationalIdNumber,
    string Name,
    string Surname,
    string Number,
    DateOnly DateOfBirth,
    string Title,
    int? Salary);
