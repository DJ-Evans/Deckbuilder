using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var user = Environment.GetEnvironmentVariable("DB_USER");
        var pass = Environment.GetEnvironmentVariable("DB_PASS");
        var server = Environment.GetEnvironmentVariable("DB_SERVER");
        var db = Environment.GetEnvironmentVariable("DB_NAME");
        var os = Environment.GetEnvironmentVariable("DB_OS");
        var connectionString = "";

        if (os == "linux")
        {
            connectionString =
                $"Server={server};Database={db};User Id={user};Password={pass};Encrypt=False";
        }
        else
        {
            connectionString =
                $"Server=localhost;Database=DeckBuilder;Trusted_Connection=True; Encrypt=False";
        }
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}
