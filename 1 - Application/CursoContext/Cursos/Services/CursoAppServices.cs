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

namespace CursoIdiomas.Application.Cursos.Services
{
    public class CursoAppServices : ICursoAppServices
    {
        private readonly ICursoService _cursoService;
        public CursoAppServices(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }


        public async Task<GenericCommandsResults> GetAll()
        {
            var result = await _cursoService.GetAll();
            if(result == null) {
                return new GenericCommandsResults(false, "Não há curso registrado.", null);
            }
            var views = await CursoView.Mapping(result);

            return new GenericCommandsResults(true, "Há cursos registrados!", views);

        }

        public async Task<GenericCommandsResults> ObterCurso(Guid id)
        {
            var result = await _cursoService.ObterCurso(id);
            if (!result.IsValid) {
                return new GenericCommandsResults(false, "Não foi possível encontrar o curso", result.Notifications);
            }
           var view =  new CursoView(result);

            return new GenericCommandsResults(true, "Cursos encontrado!", view);
        }
     
        public async Task<GenericCommandsResults> RegistrarCurso(CursoDTO model)
        {
            var result = await _cursoService.RegistrarCurso(model.ToDomain());
            
            if (!result.IsValid) {
                return new GenericCommandsResults(false, "Não foi possível registrar o curso", result.Notifications);
            }
            var view = new CursoView(result);

            return new GenericCommandsResults(true, "Curso registrado com sucesso", view);

        }

        public async Task<GenericCommandsResults> AtualizarCurso(System.Guid idCurso, CursoDTO model) {
            var result = await _cursoService.AtualizarCurso(idCurso, model.ToDomain());

            if (!result.IsValid) {
                return new GenericCommandsResults(false, "Não foi possível atualizar o curso", result.Notifications);
            }
            var view = new CursoView(result);

            return new GenericCommandsResults(true, "Curso atualizado com sucesso", view);


        }

        public async Task<GenericCommandsResults> Remover(Guid id) {
            var result = await _cursoService.Remover(id);
            
            return (result == true) ? new GenericCommandsResults(true, "Curso removido com sucesso", null) : new GenericCommandsResults(false, "Não foi possível remover o curso.", null); ;
        }

    }
}
