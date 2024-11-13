namespace Movies_RestApi.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relacja wiele-do-wielu z filmami
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
