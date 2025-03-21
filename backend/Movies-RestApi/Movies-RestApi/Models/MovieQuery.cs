namespace Movies_RestApi.Models
{
    public class MovieQuery
    {
        public string searchPhrase { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
