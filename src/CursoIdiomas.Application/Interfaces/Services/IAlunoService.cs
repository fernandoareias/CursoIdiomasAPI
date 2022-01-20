using CursoIdiomas.Application.Views;
using CursoIdiomas.Application.Views.Simple;
using CursoIdiomas.Domain.Aluno.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Application.Interfaces
{
    public interface IAlunoService
    {

        Task<ActionResult<AlunoView>> Obter(System.Guid id);
        Task<ActionResult<IEnumerable<AlunoSimpleView>>> GetAll();
        Task<ActionResult<AlunoView>> Registrar(System.Guid idTurma, AlunoDto model);
        Task<ActionResult<AlunoView>> Atualizar(System.Guid idAluno, AlunoDto model);
        Task<ActionResult<object>> Remover(System.Guid id);
    }
}
