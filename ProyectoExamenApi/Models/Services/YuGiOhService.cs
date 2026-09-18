using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using ProyectoExamenApi.Models;

namespace ProyectoExamenApi.Models.Services;

public class YuGiOhService
{
    private const int PageSize = 8;
    private readonly HttpClient _httpClient;
    private readonly string _cardInfoUrl;

    public YuGiOhService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _cardInfoUrl = configuration["YuGiOhApi:CardInfoUrl"]
            ?? "https://db.ygoprodeck.com/api/v7/cardinfo.php?archetype=Blue-Eyes";
    }

    public async Task<List<YuGiOhCard>> GetCardsAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetFromJsonAsync<YuGiOhApiResponse>(_cardInfoUrl, cancellationToken);
        return response?.Data ?? [];
    }

    public async Task<YuGiOhCard?> GetCardAsync(long cardId, CancellationToken cancellationToken = default)
    {
        var url = $"https://db.ygoprodeck.com/api/v7/cardinfo.php?id={cardId}";
        var response = await _httpClient.GetFromJsonAsync<YuGiOhApiResponse>(url, cancellationToken);
        return response?.Data.FirstOrDefault();
    }

    public async Task<YuGiOhPageViewModel> GetPageAsync(int page, CancellationToken cancellationToken = default)
    {
        var model = new YuGiOhPageViewModel { PageSize = PageSize };

        try
        {
            var cards = await GetCardsAsync(cancellationToken);
            model.TotalPages = Math.Max(1, (int)Math.Ceiling(cards.Count / (double)PageSize));
            model.CurrentPage = Math.Clamp(page, 1, model.TotalPages);
            model.Cards = cards
                .Skip((model.CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
        catch (HttpRequestException)
        {
            model.TotalPages = 1;
            model.CurrentPage = 1;
            model.ErrorMessage = "No se pudo consultar la API de Yu-Gi-Oh!. Intenta nuevamente más tarde.";
        }

        return model;
    }
}
