
using CursoIdiomas.Infra.Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CursoIdiomas.API.Extensions
{
    public static class DatabaseExtensions
    {

        public static IServiceCollection UseSqlServer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(
                options => 
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                );

            return serviceCollection;
        }
    }
}
