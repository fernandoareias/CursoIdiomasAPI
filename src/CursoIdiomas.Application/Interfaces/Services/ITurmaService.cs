using CursoIdiomas.Application.Views;
using CursoIdiomas.Application.Views.Simple;
using CursoIdiomas.Domain.Turma.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Application.Interfaces
{
    public interface ITurmaService
    {

        Task<ActionResult<TurmaView>> Visualizar(System.Guid id);
        Task<ActionResult<IEnumerable<TurmaSimpleView>>> GetAllByProfessor(System.Guid idProfessor);
        Task<ActionResult<TurmaView>> Registrar(System.Guid idProfessor, TurmaDto model);
        Task<ActionResult<TurmaView>> Atualizar(System.Guid id, TurmaDto model);
        Task<ActionResult<bool>> Remover(System.Guid id);
    }
}
