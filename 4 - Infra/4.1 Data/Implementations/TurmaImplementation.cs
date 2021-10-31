using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Repositories;
using CursoIdiomas.Infra.Data.Context;
using CursoIdiomas.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Data.Implementations {
    public class TurmaImplementation : BaseRepository<Turma>, ITurmaRepository {
        private DbSet<Turma> _dataset;

        public TurmaImplementation(MyContext context) : base(context) {
            _dataset = context.Set<Turma>();
            
        }

        public async Task<List<Turma>> SelectByProfessor(long idProfessor) {
            return await _dataset
                .Include(x => x.Matriculas)
                .ThenInclude(x => x.Aluno)
                .Include(x => x.Professor)
                .Where(t => t.ProfessorId == idProfessor)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Turma>> SelectAsync() {
            return await _dataset
                .Include(x => x.Matriculas)
                .ThenInclude(x => x.Aluno)
                .Include(x => x.Professor)
                .ToListAsync();
                
        }


        public override async Task<Turma> SelectAsync(long id) {
            return await _dataset
                .Include(x => x.Matriculas)
                .ThenInclude(x => x.Aluno)
                .Include(x => x.Professor)
                .FirstOrDefaultAsync(t => t.Id == id);

        }
    }

}
