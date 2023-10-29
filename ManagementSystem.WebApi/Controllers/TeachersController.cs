using ManagementSystem.Application.Dtos.Requests;
using ManagementSystem.Application.Dtos;
using ManagementSystem.Application.Dtos.Results.GetTeacher;
using ManagementSystem.Application.Dtos.Results.ListTeachers;
using ManagementSystem.Application.Queries;
using ManagementSystem.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Application.Commands.AddTeacher;
using ManagementSystem.Application.Dtos.Results.AddTeacher;
using ManagementSystem.Application.Commands.DeleteTeacher;
using ManagementSystem.Application.Commands.UpdateTeacher;
using ManagementSystem.Application.Dtos.Results.DeleteTeacher;
using ManagementSystem.Application.Dtos.Results.UpdateTeacher;

namespace ManagementSystem.WebApi.Controllers;

[Route("api/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
[ApiController]
public class TeachersController : ControllerBase
{
    public TeachersController()
    {
        
    }

    /// <summary>
    /// Get teacher by id
    /// </summary>
    /// <param name="id">Id of teacher in database</param>
    /// <param name="getTeacherService">Injected service for getting teacher by id</param>
    /// <returns>Teacher info</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetTeacherSuccess), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(GetTeacherNotFound), StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public async Task<ActionResult<GetTeacherResult>> Get(
        [FromRoute] Guid id,
        [FromServices] IGetTeacher getTeacherService)
    {
        var result = await getTeacherService.Execute(id);
        return result switch
        {
            GetTeacherSuccess success => Ok(success),
            GetTeacherNotFound notFound => NotFound(notFound),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    /// Get list of teachers by page
    /// </summary>
    /// <param name="request">Request model</param>
    /// <param name="service">Injected service for getting list with teachers</param>
    /// <returns>List of teachers</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeacherListItem>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<IActionResult> List(
        [FromQuery] SearchTeachers request,
        [FromServices] IListTeachers service)
    {
        var result = await service.Execute(request);

        if (result is ListTeachersResultSuccess)
        {
            var list = (ListTeachersResultSuccess)result;

            var paginationMetadata = new PaginationMetadata(
                request.Page,
                (int)Math.Ceiling(list.TotalCount / (double)request.ItemsPerPage),
                request.ItemsPerPage,
                list.TotalCount);

            Response.AddPaginationHeader(paginationMetadata);
            return Ok(list.Data);
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Create a new teacher item in database
    /// </summary>
    /// <param name="dto">Request with data for saving</param>
    /// <param name="command">Injected service for add teacher to database</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Add(
            [FromBody] AddTeacherCommand dto,
            [FromServices] IAddTeacher command)
    {
        var result = await command.Execute(dto);

        return result switch
        {
            AddTeacherSuccess success => Ok(success),
            AddTeacherFailed failed => BadRequest(failed),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    /// Update teacher in database
    /// </summary>
    /// <param name="dto">Request with data for update</param>
    /// <param name="command">Injected service for update teacher</param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(UpdateTeacherSuccess), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Update(
            [FromBody] UpdateTeacherCommand dto,
            [FromServices] IUpdateTeacher command)
    {
        var result = await command.Execute(dto);

        return result switch
        {
            UpdateTeacherSuccess => NoContent(),
            UpdateTeacherFailed failed => BadRequest(failed),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    /// Delete teacher from database
    /// </summary>
    /// <param name="id">Id of teacher from url</param>
    /// <param name="deleteTeacherService">Injected service for delete teacher from database</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeleteTeacherSuccess), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] IDeleteTeacher deleteTeacherService)
    {
        var result = await deleteTeacherService.Execute(id);
        return result switch
        {
            DeleteTeacherSuccess => NoContent(),
            DeleteTeacherNotFound notFound => NotFound(notFound),
            DeleteTeacherFailed failed => BadRequest(failed),
            _ => throw new NotImplementedException()
        };
    }
}
