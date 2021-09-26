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
    public class BoletimImplementation : BaseRepository<Turma>, IBoletimRepository {
        private DbSet<Turma> _dataset;

        public BoletimImplementation(MyContext context) : base(context) {
            _dataset = context.Set<Turma>();
        }

    }

}
