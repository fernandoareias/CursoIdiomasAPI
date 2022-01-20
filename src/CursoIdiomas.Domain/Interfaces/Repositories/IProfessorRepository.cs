using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Repositories
{
    public interface IProfessorRepository
    {
        Task<CursoIdiomas.Domain.Entities.Professor> GetById(System.Guid id);
        Task<IEnumerable<CursoIdiomas.Domain.Entities.Professor>> GetByCourseId(System.Guid courseId);
        Task<CursoIdiomas.Domain.Entities.Professor> Cadastrar(CursoIdiomas.Domain.Entities.Professor professor);
        Task<CursoIdiomas.Domain.Entities.Professor> Atualizar(CursoIdiomas.Domain.Entities.Professor professor);
        Task<CursoIdiomas.Domain.Entities.Professor> Remover(CursoIdiomas.Domain.Entities.Professor professor);
    }
}
