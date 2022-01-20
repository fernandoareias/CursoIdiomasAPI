using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoIdiomas.Infra.Data.Mapping
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {


            builder.ToTable("Turma");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Turno)
                .HasMaxLength(50)
                .HasConversion<string>()
                .IsRequired();





            builder.HasOne(x => x.Professor).WithMany(y => y.Turmas);


        }
    }
}
