using System.Net;
using MasterNet.Application.Accounts;
using MasterNet.Application.Accounts.GetCurrentUser;
using MasterNet.Application.Accounts.Login;
using MasterNet.Application.Accounts.Register;
using MasterNet.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Accounts.GetCurrentUser.GetCurrentUserQuery;
using static MasterNet.Application.Accounts.Login.LoginCommand;
using static MasterNet.Application.Accounts.Register.RegisterCommand;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IUserAccessor _userAccessor;

    public AccountController(ISender sender, IUserAccessor userAccessor)
    {
        _sender = sender;
        _userAccessor = userAccessor;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Profile>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var command = new LoginCommandRequest(request);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : Unauthorized();
    }


    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Profile>> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        var command = new RegisterCommandRequest(request);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : Unauthorized();
    }

    [Authorize]
    [HttpGet("me")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Profile>> GetCurrentUser(CancellationToken cancellationToken)
    {
        var email = _userAccessor.GetEmail();
        var request = new GetCurrentUserRequest { Email = email };
        var query = new GetCurrentUserQueryRequest(request);
        var result = await _sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : Unauthorized();
    }
}