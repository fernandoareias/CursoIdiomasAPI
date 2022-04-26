using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CursoIdiomas.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection UseSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen( c =>
            {
                c.SwaggerDoc(name:"v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Curso de idiomas API",
                    Description = "Essa é a API do curso de idiomas.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "Fernando Calheiros", Email = "nando.calheirosx@gmail.com"},
                    License = new Microsoft.OpenApi.Models.OpenApiLicense() { Name = "MIT", Url = new System.Uri("https://opensource.org/licenses/MIT")}

                });
            });

            return serviceCollection;
        }
    }
}
