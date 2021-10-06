using CursoIdiomas.Domain.Cursos.Curso;
using CursoIdiomas.Domain.Cursos.DTO;
using CursoIdiomas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Service
{
    public interface ICursoService
    {
        
        Task<Curso> Obter(long id);
        Task<IEnumerable<Curso>> GetAll();
        Task<Curso> Registrar(CursoDTO model);
        Task<Curso> Atualizar(long idCurso, CursoDTO model);
        Task<bool> Remover(long idCurso);
    }
}
