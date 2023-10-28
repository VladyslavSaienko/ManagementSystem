namespace ManagementSystem.Application.Dtos.Results.ListTeachers;

public record ListTeachersResultSuccess(IEnumerable<TeacherListItem> Data, int TotalCount)
    : ListTeachersResult;
