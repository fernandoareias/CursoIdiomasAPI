using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Repositories;
using CursoIdiomas.Infra.Data.Context;
using CursoIdiomas.Infra.Data.Implementations;
using CursoIdiomas.Infra.Data.Repository;
using CursoIdiomas.Service.CursoServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IConfiguration Configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddTransient<ICursoRepository, CursoImplementation>();
            serviceCollection.AddTransient<IAlunoRepository, AlunoImplementation>();
            serviceCollection.AddTransient<IBoletimRepository, BoletimImplementation>();
            serviceCollection.AddTransient<IMatriculaRepository, MatriculaImplementation>();
            serviceCollection.AddTransient<IMensalidadesRepository, MensalidadesImplementation>();
            serviceCollection.AddTransient<IProfessorRepository, ProfessorImplementation>();
            serviceCollection.AddTransient<ITurmaRepository, TurmaImplementation>();

            serviceCollection.AddDbContext<MyContext>(
                  options => options.UseSqlServer($"{Configuration["ConnectionStrings:connectionString"]}"));

        }
    }
}

