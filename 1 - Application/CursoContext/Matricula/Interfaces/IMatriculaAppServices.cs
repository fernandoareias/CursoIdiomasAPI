using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.Cursos.DTO;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Matricula.Interfaces {
    public interface IMatriculaAppServices {

        Task<GenericCommandsResults> Registrar(CursoDTO model);
        Task<GenericCommandsResults> Atualizar(System.Guid idCurso, CursoDTO model);
        Task<GenericCommandsResults> Obter(Guid id);
        Task<GenericCommandsResults> Remover(Guid id);
        Task<GenericCommandsResults> GetAll();
    }
}
