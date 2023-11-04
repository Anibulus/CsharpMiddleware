using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    public IHelloWorldService _helloWorldService;
    public ILogger _logger;

    public HelloWorldController(IHelloWorldService helloWorldService, ILoggerFactory logger)
    {
        _helloWorldService = helloWorldService;
        _logger = logger.CreateLogger<HelloWorldController>();
    }

    public IActionResult Get()
    {
        _logger.LogInformation("Entrando aqui");
        return Ok(_helloWorldService.GetHelloWorld());
    }
}
