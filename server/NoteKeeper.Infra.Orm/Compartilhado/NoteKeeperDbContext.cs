using Microsoft.EntityFrameworkCore;
using NoteKeeper.Dominio.Compartilhado;
using NoteKeeper.Dominio.ModuloCategoria;
using NoteKeeper.Dominio.ModuloNota;
using NoteKeeper.Infra.Orm.ModuloCategoria;
using NoteKeeper.Infra.Orm.ModuloNota;

namespace NoteKeeper.Infra.Orm.Compartilhado
{
    public class NoteKeeperDbContext : DbContext, IContextoPersistencia
    {
        public NoteKeeperDbContext(DbContextOptions options) : base(options)
        {
        }      

        public async Task<bool> GravarAsync()
        {
            await SaveChangesAsync();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorCategoriaOrm());

            modelBuilder.ApplyConfiguration(new MapeadorNotaOrm());

            base.OnModelCreating(modelBuilder);
        }

    }
}
