using CursoIdiomas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Repositories
{
    public interface ITurmaRepository
    {
        Task<List<Turma>> GetByProfessorId(System.Guid idProfessor);
        Task<Turma> GetById(System.Guid id);
        Task<Turma> Create(Turma turma);
        Task<Turma> Update(Turma turma);
        Task<Turma> Delete(Turma turma);
    }
}
