using NoteKeeper.Dominio.Compartilhado;

namespace NoteKeeper.Dominio.ModuloNota
{
    public interface IRepositorioNota : IRepositorioBase<Nota>
    {
        Task<List<Nota>> Filtrar(Func<Nota, bool> predicate);
    }
}
