using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies_RestApi.Data;
using Movies_RestApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies_RestApi_Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Usuń oryginalny kontekst
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<DataContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                // Dodaj kontekst z InMemory bazą danych
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("TestMovieDb");
                });

                // Wstrzyknij dane testowe
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.EnsureCreated();

                // Dodaj przykładowe filmy
                db.Movies.AddRange(
                    new Movie { Id = 1, Title = "Inception", Rating = 9 },
                    new Movie { Id = 2, Title = "Interstellar", Rating = 8 },
                    new Movie { Id = 3, Title = "Tenet", Rating = 7 },
                    new Movie { Id = 4, Title = "Dunkirk", Rating = 7 },
                    new Movie { Id = 5, Title = "Batman Begins", Rating = 9 },
                    new Movie { Id = 6, Title = "The Dark Knight", Rating = 10 }
                );
                db.SaveChanges();
            });
        }
    }
}
