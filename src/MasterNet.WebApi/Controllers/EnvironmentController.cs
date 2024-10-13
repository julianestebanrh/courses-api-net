using Microsoft.AspNetCore.Mvc;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/environment")]
public class EnvironmentController : ControllerBase
{

    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public EnvironmentController(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    [HttpGet]
    public IActionResult GetEnvironment()
    {
        var environment = _environment.EnvironmentName;
        var startApp = _configuration.GetValue<string>("StartApp");
        return Ok(new
        {
            Environment = environment,
            StartApp = startApp
        });
    }

}