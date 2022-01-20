using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoIdiomas.Infra.Data.Mapping
{
    public class BoletimMap : IEntityTypeConfiguration<Boletim>
    {
        public void Configure(EntityTypeBuilder<Boletim> builder)
        {


            builder.ToTable("Boletim");
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Nota)
                .HasColumnName("Nota")
                .HasPrecision(2, 2)
                .IsRequired();

            builder.Property(x => x.UltimaAtualizacao);

            builder.Property(x => x.DataPublicacao);

            builder.HasOne(x => x.Aluno).WithMany(y => y.Boletims);
        }
    }
}
