using System.Collections.Generic;

namespace graphQLV2.Database
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
