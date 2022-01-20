using CursoIdiomas.Domain.Entities;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Repositories
{
    public interface IMatriculaRepository
    {
        Task<Matricula> Matricular(Matricula matricula);
        Task<Matricula> Atualizar(Matricula matricula);
    }
}
