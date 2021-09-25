﻿using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Data.Mapping {
    public class TurmaMap : IEntityTypeConfiguration<Turma> {
        public void Configure(EntityTypeBuilder<Turma> builder) {


            builder.ToTable("Turma");
            builder.HasKey(p => p.Id);
          
            builder.Property(x => x.DataInicio);
            builder.Property(x => x.DataFim);
            builder.Ignore(p => p.Notifications);
            builder.HasOne(x => x.Curso).WithMany(y => y.Turmas);
            builder.HasOne(x => x.Professor).WithMany(y => y.Turmas);


        }
    }
}