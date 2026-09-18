using Microsoft.AspNetCore.Mvc;
using ProyectoExamenApi.Models.Services;

namespace ProyectoExamenApi.Controllers;

public class CardController : Controller
{
    private readonly YuGiOhService _yuGiOhService;

    public CardController(YuGiOhService yuGiOhService)
    {
        _yuGiOhService = yuGiOhService;
    }

    public async Task<IActionResult> Index(int page = 1, CancellationToken cancellationToken = default)
    {
        var model = await _yuGiOhService.GetPageAsync(page, cancellationToken);
        return View(model);
    }

    public async Task<IActionResult> Details(long id, CancellationToken cancellationToken = default)
    {
        var card = await _yuGiOhService.GetCardAsync(id, cancellationToken);
        return card is null ? NotFound() : View(card);
    }
}
