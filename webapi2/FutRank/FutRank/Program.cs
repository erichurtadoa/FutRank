using FutRank.Mappers;
using FutRank.Models;
using FutRank.Repositories.Implementation;
using FutRank.Repositories.Interfaces;
using FutRank.Services.Implementation;
using FutRank.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

ConfigureServices(builder);
ConfigureRepositories(builder);

builder.Services.AddScoped<ClubMapper>();
builder.Services.AddScoped<FixtureMapper>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevServer",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SampleDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAngularDevServer");

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

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IVenueService, VenueService>();
    builder.Services.AddScoped<IClubService, ClubService>();
    builder.Services.AddScoped<IFixtureService, FixtureService>();
}

void ConfigureRepositories(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IVenueRepository, VenueRepository>();
    builder.Services.AddScoped<IClubRepository, ClubRepository>();
    builder.Services.AddScoped<IFixtureRepository, FixtureRepository>();
}