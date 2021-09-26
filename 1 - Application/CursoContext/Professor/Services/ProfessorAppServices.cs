using CursoIdiomas.Application.Boletim.Interfaces;
using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.CursoContext.Professor.DTO;
using CursoIdiomas.Application.Cursos.DTO;
using CursoIdiomas.Application.Cursos.Interfaces;
using CursoIdiomas.Application.Views;
using CursoIdiomas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Professor.Services {
    public class ProfessorAppServices : IProfessorAppServices {
        private readonly IProfessorService _professorService;
        public ProfessorAppServices(IProfessorService professorService) {
            _professorService = professorService;
        }


        public async Task<GenericCommandsResults> GetAll() {
            //var result = await _professorService.GetAll();
            //if (result == null) {
            //    return new GenericCommandsResults(false, "Não há curso registrado.", null);
            //}
            //var views = await CursoView.Mapping(result);

            return new GenericCommandsResults(true, "Há cursos registrados!", true);

        }

        public async Task<GenericCommandsResults> Obter(Guid id) {
            //var result = await _professorService.Obter(id);
            //if (!result.IsValid) {
            //    return new GenericCommandsResults(false, "Não foi possível encontrar o curso", result.Notifications);
            //}
            //var view = new CursoView(result);

            return new GenericCommandsResults(true, "Cursos encontrado!", true);
        }

        public async Task<GenericCommandsResults> Registrar(ProfessorDTO model) {
            //var result = await _professorService.Registrar(model.ToDomain());

            //if (!result.IsValid) {
            //    return new GenericCommandsResults(false, "Não foi possível registrar o curso", result.Notifications);
            //}
            //var view = new CursoView(result);

            return new GenericCommandsResults(true, "Curso registrado com sucesso", true);

        }

        public async Task<GenericCommandsResults> Atualizar(System.Guid idCurso, ProfessorDTO model) {
            //var result = await _professorService.Atualizar(idCurso, model.ToDomain());

            //if (!result.IsValid) {
            //    return new GenericCommandsResults(false, "Não foi possível atualizar o curso", result.Notifications);
            //}
            //var view = new CursoView(result);

            return new GenericCommandsResults(true, "Curso atualizado com sucesso", true);


        }

        public async Task<GenericCommandsResults> Remover(Guid id) {
            var result = await _professorService.Remover(id);

            return (result == true) ? new GenericCommandsResults(true, "Curso removido com sucesso", null) : new GenericCommandsResults(false, "Não foi possível remover o curso.", null); ;
        }

    }
}
