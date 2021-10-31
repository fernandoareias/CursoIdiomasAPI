﻿using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Data.Mapping {
    public class MatriculaMap : IEntityTypeConfiguration<Matricula> {
        public void Configure(EntityTypeBuilder<Matricula> builder) {


            builder.ToTable("Matricula");
            builder.HasKey(p => p.Id);
            builder.Ignore(x => x.Notifications);
            builder.HasOne(x => x.Aluno).WithMany(y => y.Matriculas);
            builder.HasOne(x => x.Turma).WithMany(y => y.Matriculas);
            

        }
    }
}
