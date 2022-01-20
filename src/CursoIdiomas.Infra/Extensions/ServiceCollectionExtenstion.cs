using CursoIdiomas.Application.Services;
using CursoIdiomas.Domain.Application.Interfaces;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Cache;
using CursoIdiomas.Domain.Repositories;
using CursoIdiomas.Infra.Context;
using CursoIdiomas.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CursoIdiomas.Infra.Extensions
{
    public static class ServiceCollectionExtenstion
    {

        public static IServiceCollection SolveDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
            );


            services.AddScoped<DbContext, ApplicationDbContext>();

            return services;

        }
        public static IServiceCollection SolveServices(this IServiceCollection services)
        {
            services.AddTransient<ICursoService, CursoServices>();

            services.AddScoped<IAlunoService, AlunosServices>();
            services.AddScoped<IBoletimService, BoletimService>();
            services.AddScoped<IMatriculaService, MatriculaService>();
            services.AddScoped<IMensalidadesService, MensalidadeService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<ITurmaService, TurmaService>();

            return services;
        }

        public static IServiceCollection SolveRepositories(this IServiceCollection services)
        {

            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IBoletimRepository, BoletimRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            services.AddScoped<IMensalidadesRepository, MensalidadesRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();

            services.AddScoped(typeof(ICacheRepository<>), typeof(CacheRepository<>));

            return services;
        }

        public static IServiceCollection HealthCheck(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHealthChecks()
                .AddCheck("Cursos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddRedis(configuration.GetConnectionString("RedisConnection"), name: "Redis")
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "SQL Server");



            return services;
        }

        
    }
}
