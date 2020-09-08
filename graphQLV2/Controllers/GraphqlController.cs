using System.Threading.Tasks;
using GraphQL;
using graphQLV2.GraphQL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;


namespace graphQLV2.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphqlController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
        {
            Console.WriteLine("GraphQLQuery: Query: {0}", query.Query);

            var schema = new CustomSchema();
            var inputs = query.Variables != null ? new Inputs((System.Collections.Generic.IDictionary<string, object>)query.Variables) : null;

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema.GraphQLSchema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            var json = JsonSerializer.Serialize(result.Data);
            Console.WriteLine("json result: {0}", json);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }


    }
}
