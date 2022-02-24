global using HeroAPI.Data;
using HeroAPI.Repositories;
using HeroAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//This option can be used when there is only one repo to be registered
//builder.Services.AddTransient<ISuperHeroRepository, SuperHeroRepository>();

builder.Services.RegisterRepos();
builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public static class ServiceExtensions
{
    public static void RegisterRepos(this IServiceCollection collection)
    {
        collection.AddTransient<ISuperHeroRepository, SuperHeroRepository>();
        //Add other repositories
    }

    public static void RegisterServices(this IServiceCollection collection)
    {
        collection.AddTransient<ISuperHeroService, SuperHeroService>();
    }
}