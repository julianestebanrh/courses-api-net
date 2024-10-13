using System.Net;
using MasterNet.Application.Core;
using MasterNet.Application.Instructors.GetInstructors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Instructors.GetInstructors.GetInstructorsQuery;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/instructors")]
public class InstructorsController : ControllerBase
{
    private readonly ISender _sender;

    public InstructorsController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Pagination<InstructorResponse>>> GetInstructors([FromQuery] GetInstructorsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetInstructorsQueryRequest { InstructorsRequest = request };
        var result = await _sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }
}