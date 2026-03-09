using Deckbuilder.Server.Repositories;
using Deckbuilder.Server.Repositories.Interfaces;
using Deckbuilder.Server.Services;
using Deckbuilder.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
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
        $"Server=localhost;Database=DeckBuilder;Trusted_Connection=true; Encrypt=False";
}

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAngularDev",
        policy =>
            policy
                .WithOrigins(
                    "http://localhost:55282",
                    "https://localhost:55282",
                    "http://127.0.0.1:55282"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
    );
});

// Register services and repositories
builder.Services.AddTransient<IDeckService, DeckService>();
builder.Services.AddTransient<IDeckRepository, DeckRepository>();
builder.Services.AddTransient<IScryfallService, ScryfallService>();
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<IDeckCardService, DeckCardService>();
builder.Services.AddTransient<IDeckCardRepository, DeckCardRepository>();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("AllowAngularDev");

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
