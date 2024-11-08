using Microsoft.EntityFrameworkCore;
using NoteKeeper.Dominio.Compartilhado;
using NoteKeeper.Dominio.ModuloNota;
using NoteKeeper.Infra.Orm.Compartilhado;

namespace NoteKeeper.Infra.Orm.ModuloNota
{
    public class RepositorioNotaOrm : RepositorioBase<Nota>, IRepositorioNota
    {
        public RepositorioNotaOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
        }

        public override async Task<Nota> SelecionarPorIdAsync(Guid id)
        {
            return await registros.Include(x => x.Categoria).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
