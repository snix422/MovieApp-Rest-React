using System.IO;

namespace Movies_RestApi.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public ICollection<Actor> Actors { get; set; } = new List<Actor>();

        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public int ProductionDetailsId { get; set; }
        public ProductionDetails ProductionDetails { get; set; }

        public List<Review> Reviews { get; set; }
        public string ImageUrl { get; set; }
        public double Rating { get; set; }
    }
}
