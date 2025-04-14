namespace Shared.Models;

public class Diet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Meal> Meals { get; set; }
}
