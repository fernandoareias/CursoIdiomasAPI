using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.Cursos.DTO;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Aluno.Interfaces {
    public interface IAlunoAppServices {

        Task<GenericCommandsResults> Registrar(CursoDTO model);
        Task<GenericCommandsResults> Atualizar(System.Guid id, CursoDTO model);
        Task<GenericCommandsResults> Obter(Guid id);
        Task<GenericCommandsResults> Remover(Guid id);
        Task<GenericCommandsResults> GetAll();
    }
}
