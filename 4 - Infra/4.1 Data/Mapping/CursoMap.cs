using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIdiomas.Infra.Data.Mapping
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            
        
            builder.ToTable("Curso");
            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.Notifications);
            builder.Property(x => x.Nome).HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.CargaHoraria);
            builder.Property(x => x.Dificuldade);
            
            
        }
    }
}
