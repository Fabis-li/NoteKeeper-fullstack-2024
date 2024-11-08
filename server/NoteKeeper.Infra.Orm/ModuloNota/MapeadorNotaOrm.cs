using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteKeeper.Dominio.ModuloNota;

namespace NoteKeeper.Infra.Orm.ModuloNota
{
    public class MapeadorNotaOrm : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.ToTable("TBNota");

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Titulo)
                .IsRequired();

            builder.Property(x => x.Conteudo)
              .IsRequired();

            builder.Property(x => x.Arquivada)
                .HasColumnType("bit")
                .IsRequired();

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Notas)
                .HasForeignKey(x => x.CategoriaId)
                .HasConstraintName("FK_TBCategoria_TBNota")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
