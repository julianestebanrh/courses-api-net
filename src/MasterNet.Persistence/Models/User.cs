using Microsoft.AspNetCore.Identity;

namespace MasterNet.Persistence.Models;

public class User : IdentityUser
{
    public string? FullName { get; set; }
    public string? Career { get; set; }
}