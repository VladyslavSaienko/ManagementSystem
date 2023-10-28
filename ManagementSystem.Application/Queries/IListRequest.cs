namespace ManagementSystem.Application.Queries;

public interface IListRequest
{
    int Page { get; }
    int ItemsPerPage { get; }
}
