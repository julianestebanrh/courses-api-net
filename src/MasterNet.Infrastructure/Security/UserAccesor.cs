using System.Security.Claims;
using MasterNet.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MasterNet.Infrastructure.Security;


public class UserAccesor : IUserAccessor
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UserAccesor(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string GetEmail()
    {
        return _contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Email)!;
    }

    public string GetUserName()
    {
        return _contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Name)!;
    }
}