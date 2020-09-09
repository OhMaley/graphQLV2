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
        public Movie AddMovie(string title, string year, string director)
        {
            using (var db = new StoreContext())
            {
                var movie = new Movie() { Title = title, Year = year, Director = director };
                db.Movies.Add(movie);
                db.SaveChanges();
                return movie;
            }
        }

        [GraphQLMetadata("addActorToMovie")]
        public Actor AddActorToMovie(int id, string name, string character)
        {
            using (var db = new StoreContext())
            {
                var movie = db.Movies
                    .Include(m => m.Actors)
                    .SingleOrDefault(m => m.Id == id);
                if (!(movie is null))
                {
                    var actor = new Actor() { Name = name, Character = character };
                    movie.Actors.Add(actor);
                    db.SaveChanges();
                    return actor;
                }
                return null;
            }
        }
    }
}
