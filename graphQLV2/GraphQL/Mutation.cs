using graphQLV2.Database;
using GraphQL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace graphQLV2.GraphQL
{
    [GraphQLMetadata("Mutation")]
    public class Mutation
    {
        [GraphQLMetadata("addMovie")]
        public Movie AddMovie(string title)
        {
            using (var db = new StoreContext())
            {
                var movie = new Movie() { Title = title };
                db.Movies.Add(movie);
                db.SaveChanges();
                return movie;
            }
        }

        [GraphQLMetadata("addActorToMovie")]
        public Movie AddActorToMovie(int id, string name)
        {
            Console.WriteLine("movieId {0}", id);
            Console.WriteLine("name {0}", name);
            using (var db = new StoreContext())
            {
                var movie = db.Movies
                    .Include(m => m.Actors)
                    .SingleOrDefault(m => m.Id == id);
                if (!(movie is null))
                {
                    var actor = new Actor() { Name = name };
                    movie.Actors.Add(actor);
                    db.SaveChanges();
                }
                return movie;
            }
        }
    }
}
