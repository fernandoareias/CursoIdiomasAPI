using CursoIdiomas.Application.Cursos.Interfaces;
using CursoIdiomas.Application.Cursos.Services;
using CursoIdiomas.Domain.Interfaces.Service;
using CursoIdiomas.Service.CursoServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICursoAppServices, CursoAppServices>();
            serviceCollection.AddTransient<ICursoService, CursoServices>();
        }
    }
}
