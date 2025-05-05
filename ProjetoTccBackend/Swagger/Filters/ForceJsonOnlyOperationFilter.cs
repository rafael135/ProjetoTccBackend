using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProjetoTccBackend.Swagger.Filters
{
    public class ForceJsonOnlyOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Remove todos os tipos de mídia de entrada que não sejam application/json
            if (operation.RequestBody?.Content != null)
            {
                var keysToRemove = operation.RequestBody.Content.Keys
                    .Where(k => !k.Equals("application/json", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                foreach (var key in keysToRemove)
                    operation.RequestBody.Content.Remove(key);
            }

            // Remove todos os tipos de mídia de saída que não sejam application/json
            foreach (var response in operation.Responses)
            {
                var keysToRemove = response.Value.Content.Keys
                    .Where(k => !k.Equals("application/json", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                foreach (var key in keysToRemove)
                    response.Value.Content.Remove(key);
            }
        }
    }
}
