namespace ManagementSystem.Application.Dtos.Results.ListStudents;

public record ListStudentsResultSuccess(IEnumerable<StudentListItem> Data, int TotalCount)
    : ListStudentsResult;
