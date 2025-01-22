using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UrlShortener.API.Filters
{
    public class AddResponseHeadersFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Responses.ContainsKey("302"))
            {
                operation.Responses["302"].Headers.Add("Location", new OpenApiHeader
                {
                    Description = "URL of the redirect location",
                    Schema = new OpenApiSchema { Type = "string" }
                });
            }
        }
    }
}
