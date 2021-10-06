using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.Cursos.DTO;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Aluno.Interfaces {
    public interface IAlunoAppServices {

        Task<GenericCommandsResults> Registrar(CursoDTO model);
        Task<GenericCommandsResults> Atualizar(long id, CursoDTO model);
        Task<GenericCommandsResults> Obter(long id);
        Task<GenericCommandsResults> Remover(long id);
        Task<GenericCommandsResults> GetAll();
    }
}
