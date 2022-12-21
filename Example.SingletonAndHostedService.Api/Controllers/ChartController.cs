using Example.SingletonAndHostedService.Api.Models;
using Example.SingletonAndHostedService.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.SingletonAndHostedService.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ChartController : ControllerBase
{
    private readonly IMyInMemorySingletonService _myInMemorySingletonService;

    public ChartController(IMyInMemorySingletonService myInMemorySingletonService)
    {
        _myInMemorySingletonService = myInMemorySingletonService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        MyChart? chart = _myInMemorySingletonService.GetMyChartCache();

        return Ok(chart);
    }
}
