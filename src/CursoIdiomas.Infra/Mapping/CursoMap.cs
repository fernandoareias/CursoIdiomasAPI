using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoIdiomas.Infra.Data.Mapping
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {


            builder.ToTable("Curso");
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(120)")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.CargaHoraria)
                .HasMaxLength(9999)
                .IsRequired();

            builder.Property(x => x.Dificuldade)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired();


        }
    }
}
