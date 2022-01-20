using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoIdiomas.Infra.Data.Mapping
{
    public class MatriculaMap : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {


            builder.ToTable("Matricula");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Status)
                .HasConversion<string>()
                .HasMaxLength(40)
                .IsRequired();

            builder.HasOne(x => x.Aluno).WithMany(y => y.Matriculas);
            builder.HasOne(x => x.Turma).WithMany(y => y.Matriculas);


        }
    }
}
