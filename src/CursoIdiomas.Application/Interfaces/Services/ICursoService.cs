using CursoIdiomas.Application.Views;
using CursoIdiomas.Application.Views.Simple;
using CursoIdiomas.Domain.Cursos.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Application.Interfaces
{
    public interface ICursoService
    {

        Task<ActionResult<CursoView>> Obter(System.Guid id);
        Task<ActionResult<IEnumerable<CursoSimpleView>>> GetAll();
        Task<ActionResult<CursoView>> Registrar(CursoDto model);
        Task<ActionResult<CursoView>> Atualizar(System.Guid idCurso, CursoDto model);
        Task<ActionResult<object>> Remover(System.Guid idCurso);
    }
}
