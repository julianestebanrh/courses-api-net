using System.Net;
using MasterNet.Application.Core;
using MasterNet.Application.Prices.GetPrices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Prices.GetPrices.GetPricesQuery;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/prices")]
public class PricesController : ControllerBase
{
    private readonly ISender _sender;

    public PricesController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Pagination<PriceResponse>>> GetPrices([FromQuery] GetPricesRequest request, CancellationToken cancellationToken)
    {
        var query = new GetPricesQueryRequest { PricesRequest = request };
        var result = await _sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }
}