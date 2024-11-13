namespace Movies_RestApi.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Relacja jeden-do-wielu z filmami
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
