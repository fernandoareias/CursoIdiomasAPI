using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.Cursos.DTO;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Matricula.Interfaces {
    public interface IMatriculaAppServices {

        Task<GenericCommandsResults> Registrar(CursoDTO model);
        Task<GenericCommandsResults> Atualizar(long idCurso, CursoDTO model);
        Task<GenericCommandsResults> Obter(long id);
        Task<GenericCommandsResults> Remover(long id);
        Task<GenericCommandsResults> GetAll();
    }
}
