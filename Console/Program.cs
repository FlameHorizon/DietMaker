using Microsoft.EntityFrameworkCore;
using Shared.Models;

using var ctx = new DietDbContext();

DateTime start = DateTime.Parse("2025-04-14");
DateTime end = DateTime.Parse("2025-04-15");

Diet diet = ctx
    .Diets
    .Where(x => x.Id == 1)
    .Include(x => x.Meals.Where(x => x.ActiveOn >= start && x.ActiveOn <= end))
    .ThenInclude(x => x.Ingredients)
    .AsNoTracking()
    .First();

List<Meal> meals = diet.Meals.Where(x => x.Name != "Lunch").ToList();

var dict = new Dictionary<string, double>();

foreach (Meal meal in meals)
{
    foreach (Ingredient ing in meal.Ingredients)
    {
        string raw = ing.Quantity.Replace(" g", "").Replace(".", ",");
        double value = Convert.ToDouble(raw);
        if (dict.ContainsKey(ing.Name))
        {
            dict[ing.Name] += value;
        }
        else
        {
            dict.Add(ing.Name, value);
        }
    }
}

string startFormat = start.ToString("yyyy-MM-dd");
string endFormat = end.ToString("yyyy-MM-dd");

System.Console.WriteLine($"Lista zakupów: {startFormat} - {endFormat}");
foreach (var kvp in dict.OrderBy(x => x.Key))
{
    System.Console.WriteLine($"{kvp.Key}, {kvp.Value * 2} g");
}
