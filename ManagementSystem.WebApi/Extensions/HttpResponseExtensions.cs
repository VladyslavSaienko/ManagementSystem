using ManagementSystem.Application.Dtos;
using Microsoft.Extensions.Primitives;
using System.Text.Json;

namespace ManagementSystem.WebApi.Extensions;

public static class HttpResponseExtensions
{
    private const string AccessControlExposeHeaders = "Access-Control-Expose-Headers";
    private const string XPaginationHeader = "X-Pagination";
    public static void AddPaginationHeader(this HttpResponse response, PaginationMetadata paginationMetadata)
    {
        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        response.Headers.AccessControlExposeHeaders = StringValues.Concat(response.Headers.AccessControlExposeHeaders, XPaginationHeader);
        response.Headers.Add(XPaginationHeader, JsonSerializer.Serialize(paginationMetadata, options));
    }
}
