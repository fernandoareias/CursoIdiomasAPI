using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Professor;
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
    public class ProfessorImplementation : BaseRepository<CursoIdiomas.Domain.Entities.Professor>, IProfessorRepository {
        private DbSet<CursoIdiomas.Domain.Entities.Professor> _dataset;

        public ProfessorImplementation(MyContext context) : base(context) {
            _dataset = context.Set<CursoIdiomas.Domain.Entities.Professor>();
        }


        public async override Task<Professor> SelectAsync(long id) {
            var query = await _dataset
                .Include(p => p.Curso)
                .Include(p => p.Turmas)
                .FirstOrDefaultAsync(p => p.Id == id);
               

            return query;
        }

    }

}
