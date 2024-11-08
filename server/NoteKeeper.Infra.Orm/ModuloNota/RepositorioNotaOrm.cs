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


        public override async Task<List<Nota>> SelecionarTodosAsync()
        {
            return await registros.Include(x => x.Categoria).ToListAsync();
        }
        public override async Task<Nota> SelecionarPorIdAsync(Guid id)
        {
            return await registros.Include(x => x.Categoria).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Nota>> Filtrar(Func<Nota, bool>predicate)
        {
            var notas = await registros.Include(x => x.Categoria).ToListAsync();

            return notas.Where(predicate).ToList();
        }
    }
}
