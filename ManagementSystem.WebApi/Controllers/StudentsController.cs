using ManagementSystem.Application.Commands.AddStudent;
using ManagementSystem.Application.Commands.DeleteStudent;
using ManagementSystem.Application.Commands.UpdateStudent;
using ManagementSystem.Application.Dtos;
using ManagementSystem.Application.Dtos.Requests;
using ManagementSystem.Application.Dtos.Results.AddStudent;
using ManagementSystem.Application.Dtos.Results.DeleteStudent;
using ManagementSystem.Application.Dtos.Results.GetStudent;
using ManagementSystem.Application.Dtos.Results.ListStudents;
using ManagementSystem.Application.Dtos.Results.UpdateStudent;
using ManagementSystem.Application.Queries;
using ManagementSystem.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebApi.Controllers;

[Route("api/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
[ApiController]
public class StudentsController : ControllerBase
{
    public StudentsController()
    {
    }

    /// <summary>
    /// Get student by id
    /// </summary>
    /// <param name="id">Id of student in database</param>
    /// <param name="getStudentService">Injected service for getting student by id</param>
    /// <returns>Student info</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetStudentSuccess), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(GetStudentNotFound), StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public async Task<ActionResult<GetStudentResult>> Get(
        [FromRoute] Guid id,
        [FromServices] IGetStudent getStudentService)
    {
        var result = await getStudentService.Execute(id);
        return result switch
        {
            GetStudentSuccess success => Ok(success),
            GetStudentNotFound notFound => NotFound(notFound),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    /// Get list of students by page
    /// </summary>
    /// <param name="request">Request model</param>
    /// <param name="service">Injected service for getting list with students</param>
    /// <returns>List of students</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentListItem>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<IActionResult> List(
        [FromQuery] SearchStudents request,
        [FromServices] IListStudents service)
    {
        var result = await service.Execute(request);

        if (result is ListStudentsResultSuccess)
        {
            var list = (ListStudentsResultSuccess)result;

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
    /// Create a new student item in database
    /// </summary>
    /// <param name="dto">Request with data for saving</param>
    /// <param name="command">Injected service for add student to database</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Add(
            [FromBody] AddStudentCommand dto,
            [FromServices] IAddStudent command)
    {
        var result = await command.Execute(dto);

        return result switch
        {
            AddStudentSuccess success => Ok(success),
            AddStudentFailed failed => BadRequest(failed),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    /// Update student in database
    /// </summary>
    /// <param name="dto">Request with data for update</param>
    /// <param name="command">Injected service for update student</param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(UpdateStudentSuccess), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Update(
            [FromBody] UpdateStudentCommand dto,
            [FromServices] IUpdateStudent command)
    {
        var result = await command.Execute(dto);

        return result switch
        {
            UpdateStudentSuccess => NoContent(),
            UpdateStudentFailed failed => BadRequest(failed),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    /// Delete student from database
    /// </summary>
    /// <param name="id">Id of student from url</param>
    /// <param name="deleteStudentService">Injected service for delete student from database</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeleteStudentSuccess), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] IDeleteStudent deleteStudentService)
    {
        var result = await deleteStudentService.Execute(id);
        return result switch
        {
            DeleteStudentSuccess => NoContent(),
            DeleteStudentNotFound notFound => NotFound(notFound),
            DeleteStudentFailed failed => BadRequest(failed),
            _ => throw new NotImplementedException()
        };
    }
}
