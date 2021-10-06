using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.Cursos.DTO;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Cursos.Interfaces {
    public interface ICursoAppServices
    {

        Task<GenericCommandsResults> RegistrarCurso(CursoDTO model);
        Task<GenericCommandsResults> AtualizarCurso(long idCurso, CursoDTO model);
        Task<GenericCommandsResults> ObterCurso(long id);
        Task<GenericCommandsResults> Remover(long id);
        Task<GenericCommandsResults> GetAll();
    }
}
