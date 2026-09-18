using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoExamenApi.Models;
using ProyectoExamenApi.Models.Services;

namespace ProyectoExamenApi.Controllers;

public class HomeController : Controller
{
    private readonly YuGiOhService _yuGiOhService;

    public HomeController(YuGiOhService yuGiOhService)
    {
        _yuGiOhService = yuGiOhService;
    }

    public async Task<IActionResult> Index(int page = 1, CancellationToken cancellationToken = default)
    {
        var model = await _yuGiOhService.GetPageAsync(page, cancellationToken);
        return View("~/Views/Card/Index.cshtml", model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
