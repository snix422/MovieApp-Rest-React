using Movies_RestApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.Json.Serialization;
using Movies_RestApi;
using NLog.Extensions.Logging;
using Movies_RestApi.Middlewares;
using Movies_RestApi.Services;
using FluentValidation;
using Movies_RestApi.Models.Validators;
using Movies_RestApi.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Logging.ClearProviders();
builder.Logging.AddNLog();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IValidator<MovieQuery>,MovieQueryValidator>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(@"Data Source=DESKTOP-J87EI3O\MSSQ2LSERVER;Initial Catalog=MoviesApiStudy;Integrated Security=True;TrustServerCertificate=True;"));
builder.Services.AddAutoMapper(typeof(MovieMappingProfile).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy => policy.WithOrigins("http://localhost:3000") // Dodaj URL swojego frontendu
                       .AllowAnyMethod()
                       .AllowAnyHeader());
});



var app = builder.Build();

app.UseCors("AllowLocalhost");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }