using Microsoft.EntityFrameworkCore;
using Movies_RestApi.Entities;

namespace Movies_RestApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacja wiele-do-jednego z gatunkiem
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            // Relacja wiele-do-jednego z reżyserem
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId);

            modelBuilder.Entity<Movie>()
    .HasMany(m => m.Actors)
    .WithMany(a => a.Movies)
    .UsingEntity<Dictionary<string, object>>(
        "MovieActor", // Nazwa tabeli
        j => j.HasOne<Actor>().WithMany().HasForeignKey("ActorId"), // Klucz obcy dla aktora
        j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"), // Klucz obcy dla filmu
        j =>
        {
            j.HasKey("MovieId", "ActorId"); // Klucz główny złożony
        });



            // Relacja jeden-do-jednego z detalami produkcji
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.ProductionDetails)
                .WithOne()
                .HasForeignKey<Movie>(m => m.ProductionDetailsId);

            // Relacja jeden-do-wielu z recenzjami
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId);

            // Wymuszenie wymagalności pól
            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .IsRequired();
            modelBuilder.Entity<Review>()
                .Property(r => r.Comment)
                .IsRequired();
            modelBuilder.Entity<Review>()
                .Property(r => r.AuthorName)
                .IsRequired();

            modelBuilder.Entity<Actor>()
                .Property(a => a.LastName)
                .IsRequired();

            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .IsRequired();

            modelBuilder.Entity<Director>()
                .Property(d => d.LastName)
                .IsRequired();

            modelBuilder.Entity<ProductionDetails>()
                .Property(pd => pd.Studio)
                .IsRequired();
            modelBuilder.Entity<ProductionDetails>()
                .Property(p => p.Budget)
                .HasColumnType("decimal(18,2)");

            // Ewentualne dane do wstępnego załadowania
            SeedData(modelBuilder);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
       new Genre { Id = 1, Name = "Action" },
       new Genre { Id = 2, Name = "Drama" },
       new Genre { Id = 3, Name = "Comedy" },
       new Genre { Id = 4, Name = "Horror" },
       new Genre { Id = 5, Name = "Science Fiction" },
       new Genre { Id = 6, Name = "Fantasy" },
       new Genre { Id = 7, Name = "Adventure" }
   );

            // Reżyserzy
            modelBuilder.Entity<Director>().HasData(
                new Director { Id = 1, FirstName = "Steven", LastName = "Spielberg" },
                new Director { Id = 2, FirstName = "Christopher", LastName = "Nolan" },
                new Director { Id = 3, FirstName = "Quentin", LastName = "Tarantino" },
                new Director { Id = 4, FirstName = "Martin", LastName = "Scorsese" },
                new Director { Id = 5, FirstName = "James", LastName = "Cameron" }
            );

            // Aktorzy
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "Leonardo", LastName = "DiCaprio" },
                new Actor { Id = 2, FirstName = "Brad", LastName = "Pitt" },
                new Actor { Id = 3, FirstName = "Scarlett", LastName = "Johansson" },
                new Actor { Id = 4, FirstName = "Tom", LastName = "Hanks" },
                new Actor { Id = 5, FirstName = "Natalie", LastName = "Portman" },
                new Actor { Id = 6, FirstName = "Johnny", LastName = "Depp" },
                new Actor { Id = 7, FirstName = "Morgan", LastName = "Freeman" }
            );

            // Filmy
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", GenreId = 5, DirectorId = 2, ProductionDetailsId = 1 },
                new Movie { Id = 2, Title = "Pulp Fiction", GenreId = 2, DirectorId = 3, ProductionDetailsId = 2 },
                new Movie { Id = 3, Title = "Jurassic Park", GenreId = 1, DirectorId = 1, ProductionDetailsId = 3 },
                new Movie { Id = 4, Title = "The Revenant", GenreId = 2, DirectorId = 4, ProductionDetailsId = 4 },
                new Movie { Id = 5, Title = "Titanic", GenreId = 2, DirectorId = 5, ProductionDetailsId = 5 },
                new Movie { Id = 6, Title = "The Dark Knight", GenreId = 1, DirectorId = 2, ProductionDetailsId = 6 },
                new Movie { Id = 7, Title = "Avatar", GenreId = 6, DirectorId = 5, ProductionDetailsId = 7 },
                new Movie { Id = 8, Title = "Interstellar", GenreId = 5, DirectorId = 2, ProductionDetailsId = 8 },
                new Movie { Id = 9, Title = "The Godfather", GenreId = 2, DirectorId = 4, ProductionDetailsId = 9 },
                new Movie { Id = 10, Title = "The Matrix", GenreId = 5, DirectorId = 1, ProductionDetailsId = 10 },
                new Movie { Id = 11, Title = "Gladiator", GenreId = 7, DirectorId = 3, ProductionDetailsId = 11 },
                new Movie { Id = 12, Title = "The Wolf of Wall Street", GenreId = 2, DirectorId = 4, ProductionDetailsId = 12 },
                new Movie { Id = 13, Title = "Pirates of the Caribbean", GenreId = 7, DirectorId = 1, ProductionDetailsId = 13 },
                new Movie { Id = 14, Title = "The Avengers", GenreId = 1, DirectorId = 2, ProductionDetailsId = 14 },
                new Movie { Id = 15, Title = "Fight Club", GenreId = 2, DirectorId = 3, ProductionDetailsId = 15 }
            );

            // Szczegóły produkcji
            modelBuilder.Entity<ProductionDetails>().HasData(
                new ProductionDetails { Id = 1, Studio = "Warner Bros", Budget = 160000000 },
                new ProductionDetails { Id = 2, Studio = "Miramax", Budget = 8000000 },
                new ProductionDetails { Id = 3, Studio = "Universal Pictures", Budget = 63000000 },
                new ProductionDetails { Id = 4, Studio = "20th Century Fox", Budget = 135000000 },
                new ProductionDetails { Id = 5, Studio = "Paramount Pictures", Budget = 200000000 },
                new ProductionDetails { Id = 6, Studio = "Warner Bros", Budget = 185000000 },
                new ProductionDetails { Id = 7, Studio = "Lightstorm Entertainment", Budget = 237000000 },
                new ProductionDetails { Id = 8, Studio = "Paramount Pictures", Budget = 165000000 },
                new ProductionDetails { Id = 9, Studio = "Paramount Pictures", Budget = 6000000 },
                new ProductionDetails { Id = 10, Studio = "Warner Bros", Budget = 63000000 },
                new ProductionDetails { Id = 11, Studio = "DreamWorks", Budget = 103000000 },
                new ProductionDetails { Id = 12, Studio = "Paramount Pictures", Budget = 100000000 },
                new ProductionDetails { Id = 13, Studio = "Walt Disney Pictures", Budget = 140000000 },
                new ProductionDetails { Id = 14, Studio = "Marvel Studios", Budget = 220000000 },
                new ProductionDetails { Id = 15, Studio = "20th Century Fox", Budget = 63000000 }
            );

            // Recenzje
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, MovieId = 1, AuthorName = "John", Comment = "Amazing movie!" },
                new Review { Id = 2, MovieId = 2, AuthorName = "Alice", Comment = "A true classic!" },
                new Review { Id = 3, MovieId = 3, AuthorName = "Robert", Comment = "Very exciting!" },
                new Review { Id = 4, MovieId = 4, AuthorName = "Emily", Comment = "Great acting!" },
                new Review { Id = 5, MovieId = 5, AuthorName = "Mark", Comment = "Loved the story." },
                new Review { Id = 6, MovieId = 6, AuthorName = "Sophia", Comment = "Fantastic visuals!" },
                new Review { Id = 7, MovieId = 7, AuthorName = "David", Comment = "A must-watch!" },
                new Review { Id = 8, MovieId = 8, AuthorName = "Chris", Comment = "Very emotional!" },
                new Review { Id = 9, MovieId = 9, AuthorName = "Sarah", Comment = "An all-time favorite!" },
                new Review { Id = 10, MovieId = 10, AuthorName = "Anna", Comment = "Mind-blowing!" },
                new Review { Id = 11, MovieId = 11, AuthorName = "Tom", Comment = "Epic battles!" },
                new Review { Id = 12, MovieId = 12, AuthorName = "Paul", Comment = "Very entertaining!" },
                new Review { Id = 13, MovieId = 13, AuthorName = "Laura", Comment = "A fun adventure!" },
                new Review { Id = 14, MovieId = 14, AuthorName = "Diana", Comment = "Superheroes at their best!" },
                new Review { Id = 15, MovieId = 15, AuthorName = "Steve", Comment = "A masterpiece!" }
            );
        }
    }
}

