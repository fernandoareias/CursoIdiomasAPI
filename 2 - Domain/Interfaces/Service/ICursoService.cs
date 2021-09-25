using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service
{
    public interface ICursoService
    {
        
        Task<Curso> ObterCurso(Guid id);
        Task<IEnumerable<Curso>> GetAll();
        Task<Curso> RegistrarCurso(CursoDTO model);
        Task<Curso> AtualizarCurso(Guid idCurso, CursoDTO model);
        Task<bool> Remover(Guid idCurso);
    }
}
