using CursoIdiomas.Application.Aluno.Interfaces;
using CursoIdiomas.Application.Boletim.Interfaces;
using CursoIdiomas.Application.Cursos.Interfaces;
using CursoIdiomas.Application.Cursos.Services;
using CursoIdiomas.Application.Matricula.Interfaces;
using CursoIdiomas.Application.Professor.Services;
using CursoIdiomas.Application.Turma.Interfaces;
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

            serviceCollection.AddTransient<IProfessorAppServices, ProfessorAppServices>();
            serviceCollection.AddTransient<IAlunoAppServices, AlunoAppServices>();
            serviceCollection.AddTransient<IBoletimAppServices, BoletimAppServices>();
            serviceCollection.AddTransient<IMatriculaAppServices, MatriculaAppServices>();
            serviceCollection.AddTransient<IMensalidadesAppServices, MensalidadesAppServices>();
            serviceCollection.AddTransient<ITurmaAppServices, TurmaAppServices>();


            serviceCollection.AddTransient<ICursoService, CursoServices>();

            serviceCollection.AddTransient<IAlunoService, AlunosServices>();
            serviceCollection.AddTransient<IBoletimService, BoletimService>();
            serviceCollection.AddTransient<IMatriculaService, MatriculaService>();
            serviceCollection.AddTransient<IMensalidadesService, MensalidadeService>();
            serviceCollection.AddTransient<IProfessorService, ProfessorService>();
            serviceCollection.AddTransient<ITurmaService, TurmaService>();
        }
    }
}
