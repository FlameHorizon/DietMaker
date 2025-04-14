using System.Text.Json.Serialization;

namespace Shared.Models;

public class Ingredient
{
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("quantity")]
    public string Quantity { get; set; }

    [JsonPropertyName("details")]
    public string Details { get; set; }

    public int MealId { get; set; }
}
