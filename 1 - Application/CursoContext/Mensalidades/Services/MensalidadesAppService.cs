using CursoIdiomas.Application.Boletim.Interfaces;
using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.CursoContext.Mensalidades;
using CursoIdiomas.Application.CursoContext.Mensalidades.DTOs;
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
    public class MensalidadesAppServices : IMensalidadesAppServices {
        private readonly IMensalidadesService _mensalidadesService;
        public MensalidadesAppServices(IMensalidadesService mensalidadesService) {
            _mensalidadesService = mensalidadesService;
        }


        public async Task<GenericCommandsResults> GetAll() {
            var result = await _mensalidadesService.GetAll();

            if (!result.Any() || result == null) return new GenericCommandsResults(false, "Não há mensalidades registradas.", null);

            var views = result.Select(m => new MensalidadeView(m));

            return new GenericCommandsResults(true, "Há mensalidades registradas!", views);
        }

        public async Task<GenericCommandsResults> Obter(long id) {
            var result = await _mensalidadesService.Obter(id);

            if (result == null) return new GenericCommandsResults(false, "Não foi possível encontrar a mensalidade informada.", null);

            var view = new MensalidadeView(result);

            return new GenericCommandsResults(true, "Mensalidade encontrado!", view);
        }

        public async Task<GenericCommandsResults> Registrar(long idAluno, MensalidadeDTO model) {
            var result = await _mensalidadesService.Registrar(idAluno, model.ToDomain());

            if (!result.IsValid) {
                return new GenericCommandsResults(false, "Não foi possível registrar o mensalidade", result.Notifications);
            }
            var view = new MensalidadeView(result);

            return new GenericCommandsResults(true, "Mensalidade registrado com sucesso", view);

        }

        public async Task<GenericCommandsResults> Atualizar(long idCurso, CursoDTO model) {
            //var result = await _mensalidadesService.Atualizar(idCurso, model.ToDomain());

            //if (!result.IsValid) {
            //    return new GenericCommandsResults(false, "Não foi possível atualizar o curso", result.Notifications);
            //}
            //var view = new CursoView(result);

            return new GenericCommandsResults(true, "Curso atualizado com sucesso", true);


        }

        public async Task<GenericCommandsResults> Remover(long id) {
            var result = await _mensalidadesService.Remover(id);

            return (result == true) ? new GenericCommandsResults(true, "Curso removido com sucesso", null) : new GenericCommandsResults(false, "Não foi possível remover o curso.", null); ;
        }

    }
}
