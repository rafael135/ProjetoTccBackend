using System.Reflection;
using ProjetoTccBackend.Swagger.Interfaces;

namespace ProjetoTccBackend.Swagger.Extensions
{
    /// <summary>
    /// Provides extension methods for registering Swagger example providers.
    /// </summary>
    public static class SwaggerExampleRegistrationExtensions
    {
        /// <summary>
        /// Registers all implementations of <see cref="ISwaggerExampleProvider{T}"/> found in the specified assembly with the service collection.
        /// </summary>
        /// <param name="services">The service collection to which the examples will be added.</param>
        /// <param name="assembly">The assembly to scan for example providers.</param>
        public static void AddSwaggerExamples(this IServiceCollection services, Assembly assembly)
        {
            var exampleTypes = assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISwaggerExampleProvider<>)).Select(i => new { Interface = i, Implementation = t }));

            foreach (var example in exampleTypes)
            {
                services.AddTransient(example.Interface, example.Implementation);
            }
        }
    }
}
