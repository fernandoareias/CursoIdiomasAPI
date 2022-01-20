using CursoIdiomas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Repositories
{
    public interface IAlunoRepository
    {

        Task<Alunos> GetById(System.Guid id);
        Task<Alunos> GetByMatricula(System.Guid matriculaId);
        Task<IEnumerable<Alunos>> GetAll();
        Task<Alunos> Create(Alunos aluno);
        Task<Alunos> Update(Alunos aluno);
        Task<Alunos> Remove(Alunos aluno);

    }
}
