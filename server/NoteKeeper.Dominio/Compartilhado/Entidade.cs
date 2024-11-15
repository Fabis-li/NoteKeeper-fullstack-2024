using NoteKeeper.Dominio.ModuloAutenticacao;

namespace NoteKeeper.Dominio.Compartilhado;

public abstract class Entidade
{
    public Guid Id { get; set; }

    public Entidade()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
}
