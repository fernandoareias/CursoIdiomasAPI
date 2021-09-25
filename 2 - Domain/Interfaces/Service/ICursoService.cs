using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service
{
    public interface ICursoService
    {
        Task<Curso> RegistrarCurso(CursoDTO model);
        Task<Curso> ObterCurso(Guid id);
        Task<IEnumerable<Curso>> GetAll();
    }
}
