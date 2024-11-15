using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteKeeper.Dominio.Compartilhado;
using NoteKeeper.Dominio.ModuloAutenticacao;
using NoteKeeper.Dominio.ModuloCategoria;
using NoteKeeper.Dominio.ModuloNota;
using NoteKeeper.Infra.Orm.ModuloCategoria;
using NoteKeeper.Infra.Orm.ModuloNota;

namespace NoteKeeper.Infra.Orm.Compartilhado;

public class NoteKeeperDbContext : IdentityDbContext<Usuario, Cargo, Guid>, IContextoPersistencia
{
    private readonly ITenantProvider tenantProvider;    

    public NoteKeeperDbContext(DbContextOptions options, ITenantProvider tenantProvider) : base(options)
    {
        this.tenantProvider = tenantProvider;
    }      

    public async Task<bool> GravarAsync()
    {
        await SaveChangesAsync();
        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var usuarioId = tenantProvider.UsuarioId;

        modelBuilder.ApplyConfiguration(new MapeadorCategoriaOrm());
        modelBuilder.Entity<Categoria>().HasQueryFilter(c => c.UsuarioId == usuarioId);

        modelBuilder.ApplyConfiguration(new MapeadorNotaOrm());
        modelBuilder.Entity<Nota>().HasQueryFilter(n => n.UsuarioId == usuarioId);

        base.OnModelCreating(modelBuilder);
    }

}
