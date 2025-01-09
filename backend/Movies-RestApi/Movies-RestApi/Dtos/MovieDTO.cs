using Movies_RestApi.Entities;

namespace Movies_RestApi.Dtos
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public List<ActorDTO> Actors { get; set; }
        public object ProductionDetails { get; set; }
        public List<Review> Reviews { get; set; }
        public string ImgUrl { get; set; }
    }
}
