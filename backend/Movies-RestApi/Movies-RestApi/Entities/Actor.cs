﻿namespace Movies_RestApi.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
