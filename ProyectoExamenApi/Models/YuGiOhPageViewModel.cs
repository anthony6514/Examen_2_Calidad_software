namespace ProyectoExamenApi.Models;

public class YuGiOhPageViewModel
{
    public List<YuGiOhCard> Cards { get; set; } = [];
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public string? ErrorMessage { get; set; }
}
