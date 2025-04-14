using Microsoft.EntityFrameworkCore;
using Shared.Models;

public class DietDbContext : DbContext
{
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Diet> Diets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        MySqlServerVersion ver = new(new Version(9, 2, 0));
        string connectionString = "Server=192.168.18.5;Port=32768;Database=Diet_Dev;Uid=root;Pwd=pass;";

        optionsBuilder.UseMySql(connectionString, ver);
    }
}

