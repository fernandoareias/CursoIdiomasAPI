using CursoIdiomas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Repositories
{
    public interface ICursoRepository
    {
        Task<Curso> GetById(System.Guid id);
        Task<IEnumerable<Curso>> GetAll();
        Task<Curso> Create(Curso curso);
        Task<Curso> Update(Curso curso);
        Task<Curso> Remove(Curso curso);
    }
}
