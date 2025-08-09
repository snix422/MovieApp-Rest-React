using System.ComponentModel.DataAnnotations;

namespace Movies_RestApi.Models
{
    public class MovieQuery
    {
        public string? searchPhrase { get; set; } = null;
        [Range(1, int.MaxValue, ErrorMessage = "Numer strony musi być liczbą dodatnią")]
        public int pageNumber { get; set; } = 1;
        [RegularExpression("^(5|10|15)$", ErrorMessage = "Ilość filmów wyszukania musi zawsze zawierać 5 , 10 lub 15")]
        public int pageSize { get; set; } = 5;
    }
}
