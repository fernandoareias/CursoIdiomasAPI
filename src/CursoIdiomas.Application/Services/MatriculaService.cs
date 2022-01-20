using CursoIdiomas.Domain.Application.Interfaces;
using CursoIdiomas.Domain.Cursos.DTO;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CursoIdiomas.Application.Services
{
    public class MatriculaService : IMatriculaService
    {
        public Task<ActionResult> Matricular(CursoDto model, long TurmaId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> Suspender(long MatriculaId)
        {
            throw new NotImplementedException();
        }
    }
}
