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

            
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

          
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId);

            modelBuilder.Entity<Movie>()
    .HasMany(m => m.Actors)
    .WithMany(a => a.Movies)
    .UsingEntity<Dictionary<string, object>>(
        "MovieActor",
        j => j.HasOne<Actor>().WithMany().HasForeignKey("ActorId"),
        j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"), 
        j =>
        {
            j.HasKey("MovieId", "ActorId");
        });



           
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.ProductionDetails)
                .WithOne()
                .HasForeignKey<Movie>(m => m.ProductionDetailsId);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId);

           
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

           
            modelBuilder.Entity<Director>().HasData(
                new Director { Id = 1, FirstName = "Steven", LastName = "Spielberg" },
                new Director { Id = 2, FirstName = "Christopher", LastName = "Nolan" },
                new Director { Id = 3, FirstName = "Quentin", LastName = "Tarantino" },
                new Director { Id = 4, FirstName = "Martin", LastName = "Scorsese" },
                new Director { Id = 5, FirstName = "James", LastName = "Cameron" }
            );

            
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "Leonardo", LastName = "DiCaprio" },
                new Actor { Id = 2, FirstName = "Brad", LastName = "Pitt" },
                new Actor { Id = 3, FirstName = "Scarlett", LastName = "Johansson" },
                new Actor { Id = 4, FirstName = "Tom", LastName = "Hanks" },
                new Actor { Id = 5, FirstName = "Natalie", LastName = "Portman" },
                new Actor { Id = 6, FirstName = "Johnny", LastName = "Depp" },
                new Actor { Id = 7, FirstName = "Morgan", LastName = "Freeman" }
            );

            
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", GenreId = 5, DirectorId = 2, ProductionDetailsId = 1,Rating = 8.5, ImageUrl = "https://m.media-amazon.com/images/I/61AYEacqlkL._AC_SL1000_.jpg" },
                new Movie { Id = 2, Title = "Pulp Fiction", GenreId = 2, DirectorId = 3, ProductionDetailsId = 2, Rating = 9, ImageUrl = "https://m.media-amazon.com/images/I/51DZpY7tfoL.__AC_SX300_SY300_QL70_ML2_.jpg" },
                new Movie { Id = 3, Title = "Jurassic Park", GenreId = 1, DirectorId = 1, ProductionDetailsId = 3, Rating = 10, ImageUrl = "https://fwcdn.pl/fpo/12/12/1212/8067050_1.10.webp" },
                new Movie { Id = 4, Title = "The Revenant", GenreId = 2, DirectorId = 4, ProductionDetailsId = 4, Rating = 7.5, ImageUrl = "https://m.media-amazon.com/images/M/MV5BYTgwNmQzZDctMjNmOS00OTExLTkwM2UtNzJmOTJhODFjOTdlXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg" },
                new Movie { Id = 5, Title = "Titanic", GenreId = 2, DirectorId = 5, ProductionDetailsId = 5, Rating = 8, ImageUrl= "https://m.media-amazon.com/images/M/MV5BYzYyN2FiZmUtYWYzMy00MzViLWJkZTMtOGY1ZjgzNWMwN2YxXkEyXkFqcGc@._V1_.jpg" },
                new Movie { Id = 6, Title = "The Dark Knight", GenreId = 1, DirectorId = 2, ProductionDetailsId = 6, Rating = 6.5, ImageUrl= "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_FMjpg_UX1000_.jpg" },
                new Movie { Id = 7, Title = "Avatar", GenreId = 6, DirectorId = 5, ProductionDetailsId = 7, Rating = 8, ImageUrl= "https://fwcdn.pl/fpo/81/78/558178/8047434_1.8.webp" },
                new Movie { Id = 8, Title = "Interstellar", GenreId = 5, DirectorId = 2, ProductionDetailsId = 8, Rating = 6.5, ImageUrl= "https://fwcdn.pl/fpo/56/29/375629/7670122_2.8.webp" },
                new Movie { Id = 9, Title = "The Godfather", GenreId = 2, DirectorId = 4, ProductionDetailsId = 9, Rating = 9, ImageUrl= "https://m.media-amazon.com/images/M/MV5BYTJkNGQyZDgtZDQ0NC00MDM0LWEzZWQtYzUzZDEwMDljZWNjXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg" },
                new Movie { Id = 10, Title = "The Matrix", GenreId = 5, DirectorId = 1, ProductionDetailsId = 10, Rating = 10, ImageUrl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfSjSWOCaw5dnDL2GT1zFd9RMCgUGw5Q2Cfg&s" },
                new Movie { Id = 11, Title = "Gladiator", GenreId = 7, DirectorId = 3, ProductionDetailsId = 11, Rating = 7.5, ImageUrl= "https://m.media-amazon.com/images/I/51GA6V6VE1L._AC_UF894,1000_QL80_.jpg" },
                new Movie { Id = 12, Title = "The Wolf of Wall Street", GenreId = 2, DirectorId = 4, ProductionDetailsId = 12, Rating = 5.5, ImageUrl= "https://fwcdn.pl/fpo/65/97/426597/7586610_1.8.webp" },
                new Movie { Id = 13, Title = "Pirates of the Caribbean", GenreId = 7, DirectorId = 1, ProductionDetailsId = 13, Rating = 8.5, ImageUrl= "https://fwcdn.pl/fpo/73/09/37309/7515192_1.3.jpg" },
                new Movie { Id = 14, Title = "The Avengers", GenreId = 1, DirectorId = 2, ProductionDetailsId = 14, Rating = 9.5, ImageUrl = "https://fwcdn.pl/fpo/15/15/371515/7611932_1.3.jpg" },
                new Movie { Id = 15, Title = "Fight Club", GenreId = 2, DirectorId = 3, ProductionDetailsId = 15, Rating = 10, ImageUrl= "https://m.media-amazon.com/images/M/MV5BOTgyOGQ1NDItNGU3Ny00MjU3LTg2YWEtNmEyYjBiMjI1Y2M5XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg" }
            );

            
            modelBuilder.Entity<ProductionDetails>().HasData(
                new ProductionDetails { Id = 1, Studio = "Warner Bros", Budget = 160000000, Duration = 110 },
                new ProductionDetails { Id = 2, Studio = "Miramax", Budget = 8000000, Duration = 135 },
                new ProductionDetails { Id = 3, Studio = "Universal Pictures", Budget = 63000000, Duration = 95 },
                new ProductionDetails { Id = 4, Studio = "20th Century Fox", Budget = 135000000, Duration = 100 },
                new ProductionDetails { Id = 5, Studio = "Paramount Pictures", Budget = 200000000, Duration  = 80 },
                new ProductionDetails { Id = 6, Studio = "Warner Bros", Budget = 185000000, Duration = 140 },
                new ProductionDetails { Id = 7, Studio = "Lightstorm Entertainment", Budget = 237000000, Duration = 160 },
                new ProductionDetails { Id = 8, Studio = "Paramount Pictures", Budget = 165000000, Duration = 125 },
                new ProductionDetails { Id = 9, Studio = "Paramount Pictures", Budget = 6000000, Duration = 100 },
                new ProductionDetails { Id = 10, Studio = "Warner Bros", Budget = 63000000, Duration = 75 },
                new ProductionDetails { Id = 11, Studio = "DreamWorks", Budget = 103000000, Duration = 90 },
                new ProductionDetails { Id = 12, Studio = "Paramount Pictures", Budget = 100000000, Duration = 100 },
                new ProductionDetails { Id = 13, Studio = "Walt Disney Pictures", Budget = 140000000, Duration = 110 },
                new ProductionDetails { Id = 14, Studio = "Marvel Studios", Budget = 220000000, Duration = 125 },
                new ProductionDetails { Id = 15, Studio = "20th Century Fox", Budget = 63000000, Duration = 105 }
            );

            
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, MovieId = 1, AuthorName = "John", Comment = "Amazing movie!", Rating = 8 },
                new Review { Id = 2, MovieId = 2, AuthorName = "Alice", Comment = "A true classic!", Rating = 10 },
                new Review { Id = 3, MovieId = 3, AuthorName = "Robert", Comment = "Very exciting!", Rating = 10 },
                new Review { Id = 4, MovieId = 4, AuthorName = "Emily", Comment = "Great acting!", Rating = 8 },
                new Review { Id = 5, MovieId = 5, AuthorName = "Mark", Comment = "Loved the story.", Rating = 9 },
                new Review { Id = 6, MovieId = 6, AuthorName = "Sophia", Comment = "Fantastic visuals!", Rating = 7 },
                new Review { Id = 7, MovieId = 7, AuthorName = "David", Comment = "A must-watch!", Rating = 8 },
                new Review { Id = 8, MovieId = 8, AuthorName = "Chris", Comment = "Very emotional!", Rating = 9 },
                new Review { Id = 9, MovieId = 9, AuthorName = "Sarah", Comment = "An all-time favorite!", Rating = 10 },
                new Review { Id = 10, MovieId = 10, AuthorName = "Anna", Comment = "Mind-blowing!", Rating = 8 },
                new Review { Id = 11, MovieId = 11, AuthorName = "Tom", Comment = "Epic battles!", Rating = 8 },
                new Review { Id = 12, MovieId = 12, AuthorName = "Paul", Comment = "Very entertaining!", Rating = 7 },
                new Review { Id = 13, MovieId = 13, AuthorName = "Laura", Comment = "A fun adventure!", Rating = 6 },
                new Review { Id = 14, MovieId = 14, AuthorName = "Diana", Comment = "Superheroes at their best!", Rating = 7 },
                new Review { Id = 15, MovieId = 15, AuthorName = "Steve", Comment = "A masterpiece!", Rating = 10 }
            );

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("MovieActor").HasData(
    new { MovieId = 1, ActorId = 1 },
    new { MovieId = 1, ActorId = 2 },
    new { MovieId = 2, ActorId = 2 },
    new { MovieId = 2, ActorId = 3 },
    new { MovieId = 3, ActorId = 1 },
    new { MovieId = 3, ActorId = 3 },
    new { MovieId = 4, ActorId = 4 },
    new { MovieId = 4, ActorId = 6 },
    new { MovieId = 5, ActorId = 7 },
    new { MovieId = 5, ActorId = 2 },
    new { MovieId = 6, ActorId = 1 },
    new { MovieId = 6, ActorId = 4 },
    new { MovieId = 7, ActorId = 6 },
    new { MovieId = 8, ActorId = 7 },
    new { MovieId = 8, ActorId = 2 },
    new { MovieId = 9, ActorId = 3 },
    new { MovieId = 9, ActorId = 1 },
    new { MovieId = 10, ActorId = 7 },
    new { MovieId = 10, ActorId = 6 },
    new { MovieId = 11, ActorId = 4 },
    new { MovieId = 12, ActorId = 3 },
    new { MovieId = 12, ActorId = 2 },
    new { MovieId = 13, ActorId = 1 },
    new { MovieId = 14, ActorId = 4 },
    new { MovieId = 15, ActorId = 6 },
    new { MovieId = 15, ActorId = 7 }
);
        }
    }
}

