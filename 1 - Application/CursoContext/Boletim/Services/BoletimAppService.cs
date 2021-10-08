using CursoIdiomas.Application.Boletim.Interfaces;
using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.CursoContext.Boletim;
using CursoIdiomas.Application.CursoContext.Boletim.DTOs;
using CursoIdiomas.Application.Cursos.DTO;
using CursoIdiomas.Application.Cursos.Interfaces;
using CursoIdiomas.Application.Views;
using CursoIdiomas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Cursos.Services {
    public class BoletimAppServices : IBoletimAppServices {
        private readonly IBoletimService _boletimService;
        public BoletimAppServices(IBoletimService boletimService) {
            _boletimService = boletimService;
        }


        public async Task<GenericCommandsResults> GetAll() {

            var result = await _boletimService.GetAll();

            if (result == null) return new GenericCommandsResults(false, "Não há boletins registrado.", null);

            var views = result.Select(b => new BoletimView(b));

            return new GenericCommandsResults(true, "Há boletins registrados!", views);
        }

        public async Task<GenericCommandsResults> Obter(long id) {
            var result = await _boletimService.Obter(id);
            if (result == null|| !result.IsValid) {
                return new GenericCommandsResults(false, "Não foi possível encontrar o boletim", result.Notifications);
            }
            var view = new BoletimView(result);

            return new GenericCommandsResults(true, "Boletim encontrado!", view);
        }

        public async Task<GenericCommandsResults> Registrar(long idAluno, BoletimDTO model) {
            var result = await _boletimService.Registrar(idAluno, model.ToDomain());

            if (!result.IsValid) {
                return new GenericCommandsResults(false, "Não foi possível registrar o boletim", result.Notifications);
            }
            var view = new BoletimView(result);

            return new GenericCommandsResults(true, "Boletim registrado com sucesso", view);

        }

        public async Task<GenericCommandsResults> Atualizar(long idCurso, CursoDTO model) {
            //var result = await _boletimService.Atualizar(idCurso, model.ToDomain());

            //if (!result.IsValid) {
            //    return new GenericCommandsResults(false, "Não foi possível atualizar o curso", result.Notifications);
            //}
            //var view = new CursoView(result);

            return new GenericCommandsResults(true, "Boletim atualizado com sucesso", true);


        }

        public async Task<GenericCommandsResults> Remover(long id) {
            var result = await _boletimService.Remover(id);

            return (result == true) ? new GenericCommandsResults(true, "Boletim removido com sucesso", null) : new GenericCommandsResults(false, "Não foi possível remover o boletim.", null); ;
        }

    }
}
