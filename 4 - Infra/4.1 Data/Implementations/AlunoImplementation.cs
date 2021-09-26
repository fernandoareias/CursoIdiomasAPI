using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Repositories;
using CursoIdiomas.Infra.Data.Context;
using CursoIdiomas.Infra.Data.Migrations;
using CursoIdiomas.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Data.Implementations {
    public class AlunoImplementation : BaseRepository<Aluno>, IAlunoRepository {
        private DbSet<Aluno> _dataset;

        public AlunoImplementation(MyContext context) : base(context) {
            _dataset = context.Set<Aluno>();
        }

    }

}
