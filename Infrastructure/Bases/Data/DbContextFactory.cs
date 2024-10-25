using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Bases.Data;

public static class DbContextFactory
{
    public static Dictionary<string, string> ConnectionStrings { get; set; }

    public static ApplicationDbContext Create(string key)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException();
        var connStr = ConnectionStrings[key];
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
