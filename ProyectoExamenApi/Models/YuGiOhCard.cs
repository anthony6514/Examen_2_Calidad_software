using System.Text.Json.Serialization;

namespace ProyectoExamenApi.Models;

public class YuGiOhApiResponse
{
    [JsonPropertyName("data")]
    public List<YuGiOhCard> Data { get; set; } = [];
}

public class YuGiOhCard
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("desc")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("atk")]
    public int? Attack { get; set; }

    [JsonPropertyName("def")]
    public int? Defense { get; set; }

    [JsonPropertyName("level")]
    public int? Level { get; set; }

    [JsonPropertyName("race")]
    public string Race { get; set; } = string.Empty;

    [JsonPropertyName("attribute")]
    public string Attribute { get; set; } = string.Empty;

    [JsonPropertyName("archetype")]
    public string Archetype { get; set; } = string.Empty;

    [JsonPropertyName("card_images")]
    public List<YuGiOhCardImage> Images { get; set; } = [];

    [JsonPropertyName("card_prices")]
    public List<YuGiOhCardPrice> Prices { get; set; } = [];

    [JsonIgnore]
    public string MainImage => Images.FirstOrDefault()?.ImageUrl ?? string.Empty;

    [JsonIgnore]
    public YuGiOhCardPrice? MainPrice => Prices.FirstOrDefault();
}

public class YuGiOhCardImage
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; } = string.Empty;

    [JsonPropertyName("image_url_small")]
    public string SmallImageUrl { get; set; } = string.Empty;

    [JsonPropertyName("image_url_cropped")]
    public string CroppedImageUrl { get; set; } = string.Empty;
}

public class YuGiOhCardPrice
{
    [JsonPropertyName("cardmarket_price")]
    public string Cardmarket { get; set; } = string.Empty;

    [JsonPropertyName("tcgplayer_price")]
    public string Tcgplayer { get; set; } = string.Empty;

    [JsonPropertyName("ebay_price")]
    public string Ebay { get; set; } = string.Empty;

    [JsonPropertyName("amazon_price")]
    public string Amazon { get; set; } = string.Empty;

    [JsonPropertyName("coolstuffinc_price")]
    public string CoolStuffInc { get; set; } = string.Empty;
}
