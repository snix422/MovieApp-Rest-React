using Movies_RestApi.Entities;

namespace Movies_RestApi.Models
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public decimal Budget { get; set; }
        public int Duration { get; set; }
        public string Studio { get; set; }
        public string DirectorName { get; set; }
        public string DirectorSurname { get; set; }
        public double Rating { get; set; }
        public List<ActorDTO> Actors { get; set; }

        public List<ReviewDTO> Reviews { get; set; }



    }
}
