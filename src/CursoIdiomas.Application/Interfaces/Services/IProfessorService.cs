using CursoIdiomas.Application.Views;
using CursoIdiomas.Domain.Professor.DTO;
using CursoIdiomas.Domain.Professor.View.Simple;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Application.Interfaces
{
    public interface IProfessorService
    {

        Task<ActionResult<ProfessorView>> Obter(System.Guid idProfessor);
        Task<ActionResult<IEnumerable<ProfessorSimpleView>>> GetAll(System.Guid idCurso);
        Task<ActionResult<ProfessorView>> Registrar(System.Guid idCurso, ProfessorDto model);
        Task<ActionResult<ProfessorView>> Atualizar(System.Guid idProfessor, ProfessorDto model);
        Task<ActionResult<bool>> Remover(System.Guid idProfessor);
    }
}
