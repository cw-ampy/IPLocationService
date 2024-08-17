using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IPLocationService.Models;
using Location.Interfaces.CacheService;

namespace IPLocationService.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICacheService _cacheService;

    public HomeController(ILogger<HomeController> logger, ICacheService cacheService)
    {
        _logger = logger;
        _cacheService = cacheService;
    }

    public async Task<IActionResult> IndexAsync()
    {
        string data = await _cacheService.GetFromCacheAsync("testing_key", () => getData(), new TimeSpan(15, 0, 0, 0)) ?? "";
        return View();
    }

    public IActionResult Privacy()
    { 
        return View();
    }

    private async Task<string> getData()
    {
        return "testing data 1";
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
