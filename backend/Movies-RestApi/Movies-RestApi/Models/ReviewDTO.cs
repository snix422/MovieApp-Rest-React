namespace Movies_RestApi.Models
{
    public class ReviewDTO
    {
        public string MovieTitle { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public string AuthorName { get; set; }
    }
}
