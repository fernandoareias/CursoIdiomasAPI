using CursoIdiomas.Domain.Cursos.DTO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CursoIdiomas.Domain.Application.Interfaces
{
    public interface IMatriculaService
    {

        Task<ActionResult> Matricular(CursoDto model, long TurmaId);
        Task<ActionResult> Suspender(long MatriculaId);
    }
}
