using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service
{
    public interface ICursoService
    {
        
        Task<Turma> ObterCurso(Guid id);
        Task<IEnumerable<Turma>> GetAll();
        Task<Turma> RegistrarCurso(CursoDTO model);
        Task<Turma> AtualizarCurso(Guid idCurso, CursoDTO model);
        Task<bool> Remover(Guid idCurso);
    }
}
