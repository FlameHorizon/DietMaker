using Microsoft.EntityFrameworkCore;
using Shared.Models;

using var ctx = new DietDbContext();

Diet diet = ctx
    .Diets
    .Where(x => x.Id == 1)
    .Include(x => x.Meals)
    .ThenInclude(x => x.Ingredients)
    .AsNoTracking()
    .First();

List<Meal> meals = diet.Meals.Where(x => x.Name != "Lunch").ToList();

foreach (Meal meal in meals)
{
    System.Console.WriteLine(meal.Name);
}

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

foreach (var kvp in dict.OrderBy(x => x.Key))
{
    System.Console.WriteLine($"{kvp.Key}, {kvp.Value * 2} g");
}
