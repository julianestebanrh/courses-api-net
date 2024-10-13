using System.Net;
using MasterNet.Application.Core;
using MasterNet.Application.Courses.CreateCourse;
using MasterNet.Application.Courses.GetCourse;
using MasterNet.Application.Courses.GetCourses;
using MasterNet.Application.Courses.UpdateCourse;
using MasterNet.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Courses.CreateCourse.CreateCourseCommand;
using static MasterNet.Application.Courses.DeleteCourse.DeleteCourseCommand;
using static MasterNet.Application.Courses.GetCourse.GetCourseQuery;
using static MasterNet.Application.Courses.GetCourses.GetCoursesQuery;
using static MasterNet.Application.Courses.ReportExcelCourse.ReportExcelCourseQuery;
using static MasterNet.Application.Courses.UpdateCourse.UpdateCourseCommand;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private readonly ISender _sender;

    public CoursesController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Pagination<CourseResponse>>> GetCourses([FromQuery] GetCoursesRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCoursesQueryRequest { CoursesRequest = request };
        var result = await _sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [Authorize(Policy = Constant.COURSE_CREATE)]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult<Guid>> CreateCourse([FromForm] CreateCourseRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateCourseCommandRequest(request);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [Authorize(Policy = Constant.COURSE_UPDATE)]
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Guid>> UpdateCourse([FromBody] UpdateCourseRequest request, Guid id, CancellationToken cancellationToken)
    {
        var command = new UpdateCourseCommandRequest(request, id);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest();
    }

    [Authorize(Policy = Constant.COURSE_DELETE)]
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Unit>> DeleteCourse(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteCourseCommandRequest(id);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok() : BadRequest();
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<CourseResponse>> GetCourse(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCourseQueryRequest { Id = id };
        var result = await _sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest();
    }

    [AllowAnonymous]
    [HttpGet("report")]
    public async Task<IActionResult> ReportCSV(CancellationToken cancellationToken)
    {
        var query = new ReportExcelCourseQueryRequest();
        var result = await _sender.Send(query, cancellationToken);
        byte[] excelBytes = result.ToArray();
        return File(excelBytes, "text/csv", "courses.csv");
    }


}