using System.Collections.Generic;
using GraphQL;
using System.Linq;
using graphQLV2.Database;
using Microsoft.EntityFrameworkCore;

namespace graphQLV2.GraphQL
{
    public class Query
    {
        [GraphQLMetadata("movies")]
        public IEnumerable<Movie> getMovies()
        {
            using (var db = new StoreContext())
            {
                return db.Movies
                .Include(m => m.Actors)
                .ToList();
            }
        }

        [GraphQLMetadata("movie")]
        public Movie getMovie(int id)
        {
            using (var db = new StoreContext())
            {
                return db.Movies
                .Include(m => m.Actors)
                .SingleOrDefault(m => m.Id == id);
            }
        }

        [GraphQLMetadata("actors")]
        public IEnumerable<Actor> getActors()
        {
            using (var db = new StoreContext())
            {
                return db.Actors
                .ToList();
            }
        }

        [GraphQLMetadata("actor")]
        public Actor getActor(int id)
        {
            using (var db = new StoreContext())
            {
                return db.Actors
                .SingleOrDefault(a => a.Id == id);
            }
        }
    }
}
