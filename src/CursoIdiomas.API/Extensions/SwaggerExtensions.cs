using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CursoIdiomas.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection UseSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen( c =>
            {
                c.SwaggerDoc(name: "v3", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Curso de idiomas API",
                    Description = "Essa é a API do curso de idiomas.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "Fernando Calheiros", Email = "nando.calheirosx@gmail.com"},
                    License = new Microsoft.OpenApi.Models.OpenApiLicense() { Name = "MIT", Url = new System.Uri("https://opensource.org/licenses/MIT")}

                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Bearer [TOKEN]",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
            });

            return serviceCollection;
        }
    }
}
