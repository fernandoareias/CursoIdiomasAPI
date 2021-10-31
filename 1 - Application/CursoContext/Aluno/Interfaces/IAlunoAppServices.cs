using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.CursoContext.Aluno.DTOs;
using CursoIdiomas.Application.Cursos.DTO;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Aluno.Interfaces {
    public interface IAlunoAppServices {

        Task<GenericCommandsResults> Registrar(long idTurma, AlunoCreateDTO model);
        Task<GenericCommandsResults> Atualizar(long idAluno, AlunoCreateDTO model);
        Task<GenericCommandsResults> Obter(long id);
        Task<GenericCommandsResults> Remover(long id);
        Task<GenericCommandsResults> GetAll();
    }
}
