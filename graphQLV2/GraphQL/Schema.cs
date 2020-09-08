using GraphQL.Types;

namespace graphQLV2.GraphQL
{
    public class CustomSchema
    {
        private ISchema _schema { get; set; }
        public ISchema GraphQLSchema
        {
            get
            {
                return this._schema;
            }
        }
        public CustomSchema()
        {
            this._schema = Schema.For(@"
                type Actor {
                    id: ID
                    name: String
                    character: String
                }
                
                type Movie {
                    id: ID
                    title: String
                    year: String
                    director: String
                    actors: [Actor]
                }
                
                type Query {
                    movies: [Movie]
                    movie(id: ID): Movie
                    actors: [Actor]
                    actor(id: ID): Actor
                }

                type Mutation {
                    addMovie(title: String): Movie
                    addActorToMovie(id: ID, name: String): Movie
                }
            ", _ =>
            {
                _.Types.Include<Query>();
                _.Types.Include<Mutation>();
            });
        }
    }
}
