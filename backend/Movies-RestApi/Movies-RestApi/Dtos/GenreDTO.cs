namespace Movies_RestApi.Dtos
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieDTO> Movies { get; set; }
    }
}
