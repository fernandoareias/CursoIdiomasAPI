using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Data.Mapping {
    public class AlunoMap : IEntityTypeConfiguration<Alunos> {
        public void Configure(EntityTypeBuilder<Alunos> builder) {


            builder.ToTable("Aluno");
            builder.HasKey(p => p.Id);
            builder.Ignore(x => x.Notifications);
            builder.OwnsOne(x => x.Nome);
            builder.OwnsOne(x => x.Email);
            builder.HasOne(x => x.Matricula).WithOne(m => m.Aluno);
        }
    }
}
