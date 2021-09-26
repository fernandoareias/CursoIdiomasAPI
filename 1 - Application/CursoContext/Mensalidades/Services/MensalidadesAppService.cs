using CursoIdiomas.Application.Boletim.Interfaces;
using CursoIdiomas.Application.Commands;
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
            //var result = await _mensalidadesService.GetAll();
            //if (result == null) {
            //    return new GenericCommandsResults(false, "Não há curso registrado.", null);
            //}
            //var views = await CursoView.Mapping(result);

            return new GenericCommandsResults(true, "Há cursos registrados!", true);

        }

        public async Task<GenericCommandsResults> Obter(Guid id) {
            //var result = await _mensalidadesService.Obter(id);
            //if (!result.IsValid) {
            //    return new GenericCommandsResults(false, "Não foi possível encontrar o curso", result.Notifications);
            //}
            //var view = new CursoView(result);

            return new GenericCommandsResults(true, "Cursos encontrado!", true);
        }

        public async Task<GenericCommandsResults> Registrar(CursoDTO model) {
            //var result = await _mensalidadesService.Registrar(model.ToDomain());

            //if (!result.IsValid) {
            //    return new GenericCommandsResults(false, "Não foi possível registrar o curso", result.Notifications);
            //}
            //var view = new CursoView(result);

            return new GenericCommandsResults(true, "Curso registrado com sucesso", true);

        }

        public async Task<GenericCommandsResults> Atualizar(System.Guid idCurso, CursoDTO model) {
            //var result = await _mensalidadesService.Atualizar(idCurso, model.ToDomain());

            //if (!result.IsValid) {
            //    return new GenericCommandsResults(false, "Não foi possível atualizar o curso", result.Notifications);
            //}
            //var view = new CursoView(result);

            return new GenericCommandsResults(true, "Curso atualizado com sucesso", true);


        }

        public async Task<GenericCommandsResults> Remover(Guid id) {
            var result = await _mensalidadesService.Remover(id);

            return (result == true) ? new GenericCommandsResults(true, "Curso removido com sucesso", null) : new GenericCommandsResults(false, "Não foi possível remover o curso.", null); ;
        }

    }
}
