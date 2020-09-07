using graphQLV2.Database;
using GraphQL;

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

        [GraphQLMetadata("addActor")]
        public Actor AddActor(string name)
        {
            using (var db = new StoreContext())
            {
                var actor = new Actor() { Name = name };
                db.Actors.Add(actor);
                db.SaveChanges();
                return actor;
            }
        }
    }
}
