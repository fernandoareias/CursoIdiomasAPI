using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.Cursos.DTO;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Cursos.Interfaces {
    public interface ICursoAppServices
    {

        Task<GenericCommandsResults> RegistrarCurso(CursoDTO model);
        Task<GenericCommandsResults> AtualizarCurso(System.Guid idCurso, CursoDTO model);
        Task<GenericCommandsResults> ObterCurso(Guid id);
        Task<GenericCommandsResults> Remover(Guid id);
        Task<GenericCommandsResults> GetAll();
    }
}
