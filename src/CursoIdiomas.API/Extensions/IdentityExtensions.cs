using CursoIdiomas.Infra.Data.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CursoIdiomas.API.Extensions
{
    public static class IdentityExtensions
    {

        public static IServiceCollection UseIdentity(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            return serviceCollection;
        }
    }
}
