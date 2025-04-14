using System.Text.Json.Serialization;

namespace Shared.Models;

public class Meal
{
    public int Id { get; set; }

    [JsonPropertyName("meal")]
    public string Name { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("ingredients")]
    public List<Ingredient> Ingredients { get; set; }

    [JsonPropertyName("preparation")]
    public List<string> Preparation { get; set; }

    public int DietId { get; set; }
}
