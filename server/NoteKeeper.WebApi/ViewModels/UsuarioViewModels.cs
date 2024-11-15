namespace NoteKeeper.WebApi.ViewModels;

public class RegistrarUsuarioViewModel
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
public class AutenticarUsuarioViewModel
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}
public class TokenViewModel
{
    public required string Chave { get; set; }
    public required DateTime DataExpiracao { get; set; }
    public required UsuarioTokenViewModel Usuario { get; set; }
}
public class UsuarioTokenViewModel
{
    public required Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
}