
using System.Net;
using MasterNet.Application.Core;
using MasterNet.Application.Ratings.GetRatings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Ratings.GetRatings.GetRatingsQuery;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/ratings")]
public class RatingsController : ControllerBase
{
    private readonly ISender _sender;

    public RatingsController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Pagination<RatingResponse>>> GetRatings([FromQuery] GetRatingsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetRatingsQueryRequest { RatingsRequest = request };
        var result = await _sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }
}