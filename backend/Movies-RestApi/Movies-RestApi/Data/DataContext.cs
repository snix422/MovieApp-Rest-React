using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Entities;

namespace Movies_RestApi.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            // Konfiguracja relacji jeden-do-wielu dla Movie i Director
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieActor", // EF Core automatycznie stworzy tę tabelę
                    j => j.HasOne<Actor>().WithMany().HasForeignKey("ActorId"),
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));

            SeedData(modelBuilder);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Dodaj przykładowe gatunki
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Comedy" }
            );

            // Dodaj przykładowych aktorów
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "Robert", LastName = "Downey Jr." },
                new Actor { Id = 2, FirstName = "Chris", LastName = "Evans" }
            );

            // Dodaj przykładowego reżysera
            modelBuilder.Entity<Director>().HasData(
                new Director { Id = 1, FirstName = "Christopher", LastName = "Nolan" }
            );

            // Dodaj przykładowe filmy
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", ReleaseDate = new DateTime(2010, 7, 16), DirectorId = 1 }
            );
        }
    }
}
