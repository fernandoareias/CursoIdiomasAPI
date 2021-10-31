using CursoIdiomas.Application.Commands;
using CursoIdiomas.Application.CursoContext.Turma.DTOs;
using CursoIdiomas.Application.Cursos.DTO;
using System;
using System.Threading.Tasks;

namespace CursoIdiomas.Application.Turma.Interfaces {
    public interface ITurmaAppServices {

        Task<GenericCommandsResults> Registrar(long idProfessor, TurmaDTO model);
        Task<GenericCommandsResults> Atualizar(long idTurma, TurmaDTO model);
        Task<GenericCommandsResults> Obter(long id);
        Task<GenericCommandsResults> Remover(long id);
        Task<GenericCommandsResults> GetAll();
        Task<GenericCommandsResults> GetAllByProfessor(long idProfessor);
    }
}
