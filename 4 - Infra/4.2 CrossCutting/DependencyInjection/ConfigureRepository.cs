using CursoIdiomas.Domain.Interfaces;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Domain.Repositories;
using CursoIdiomas.Infra.Data.Context;
using CursoIdiomas.Infra.Data.Implementations;
using CursoIdiomas.Infra.Data.Repository;
using CursoIdiomas.Service.CursoServices;
using Microsoft.EntityFrameworkCore;
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
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<ICursoRepository, CursoImplementation>();
            serviceCollection.AddScoped<IAlunoRepository, AlunoImplementation>();
            serviceCollection.AddScoped<IBoletimRepository, BoletimImplementation>();
            serviceCollection.AddScoped<IMatriculaRepository, MatriculaImplementation>();
            serviceCollection.AddScoped<IMensalidadesRepository, MensalidadesImplementation>();
            serviceCollection.AddScoped<IProfessorRepository, ProfessorImplementation>();
            serviceCollection.AddScoped<ITurmaRepository, TurmaImplementation>();

            serviceCollection.AddDbContext<MyContext>(
                  options => options.UseSqlServer("server=localhost,1433;database=CursoIdiomas;User ID=sa;Password=Nando@37074957"));

        }
    }
}

