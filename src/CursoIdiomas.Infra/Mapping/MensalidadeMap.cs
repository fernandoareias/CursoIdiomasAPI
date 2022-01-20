using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoIdiomas.Infra.Data.Mapping
{
    public class MensalidadesMap : IEntityTypeConfiguration<Mensalidade>
    {
        public void Configure(EntityTypeBuilder<Mensalidade> builder)
        {


            builder.ToTable("Mensalidade");
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Vencimento)
                .HasColumnName("Vencimento")
                .IsRequired();

            builder.Property(x => x.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal")
                .HasPrecision(5, 2)
                .IsRequired();

            builder.HasOne(x => x.Aluno).WithMany(y => y.Mensalidades);
        }
    }
}
