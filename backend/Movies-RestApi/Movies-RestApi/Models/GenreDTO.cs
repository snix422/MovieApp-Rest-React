namespace Movies_RestApi.Models
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieDTO> Movies { get; set; }

    }
}
