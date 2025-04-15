/*
 * Takes json file and uploads in into database
 */

using System.Text.Json;
using Shared.Models;

if (args.Length == 0)
{
    Console.WriteLine("ERR: You must provide path the file for import.");
    return;
}

string path = args[0];

if (Path.Exists(path) == false)
{
    System.Console.WriteLine($"ERR: File does not exists. Path '{path}'.");
    return;
}

string json = File.ReadAllText(path);

List<Meal>? meals = JsonSerializer.Deserialize<List<Meal>>(json);

if (meals is null)
{
    System.Console.WriteLine("$File can't be deserialized.");
    return;
}

System.Console.WriteLine($"Found '{meals.Count()}' different meals.");

using var ctx = new DietDbContext();
using var transaction = ctx.Database.BeginTransaction();

// Add diet id, for know, it will be always 1, as this is my first diet plan.
meals.ForEach(x => x.DietId = 1);

await ctx.Meals.AddRangeAsync(meals);

int affected = await ctx.SaveChangesAsync();
transaction.Commit();

System.Console.WriteLine($"{affected} rows has been added.");
System.Console.WriteLine("End.");

