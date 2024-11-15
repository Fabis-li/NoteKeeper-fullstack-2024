namespace NoteKeeper.Dominio.ModuloAutenticacao;

public interface ITenantProvider
{
    Guid? UsuarioId { get; }
}
