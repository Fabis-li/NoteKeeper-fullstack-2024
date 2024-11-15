using Microsoft.IdentityModel.Tokens;
using NoteKeeper.Dominio.ModuloAutenticacao;
using NoteKeeper.WebApi.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NoteKeeper.WebApi.Identity;

public class JsonWebTokenProvider
{
    private readonly string? chaveJwt;
    private readonly DateTime dataExpiracaoJwt;
    private string? audienciaValida;

    public JsonWebTokenProvider(IConfiguration config)
    {
        chaveJwt = config["JWT_GENERATION_KEY"];

        if (string.IsNullOrEmpty(chaveJwt))
            throw new ArgumentException("Chave de geração de tokens não configurada.");

        audienciaValida = config["Jwt:Audiencia"];

        if (string.IsNullOrEmpty(audienciaValida))
            throw new ArgumentException("Audiência válida para transmissão de tokens não configurados.");

        dataExpiracaoJwt = DateTime.UtcNow.AddHours(3);

    }

    public TokenViewModel GerarTokenAcesso(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var chaveEmBytes = Encoding.ASCII.GetBytes(chaveJwt!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = "NoteKeeper",
            Audience = audienciaValida,
            Subject = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email!),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName!)
            }),
            Expires = dataExpiracaoJwt,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(chaveEmBytes),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        var tokenString = tokenHandler.WriteToken(token);

        return new TokenViewModel
        {
            Chave = tokenString,
            DataExpiracao = dataExpiracaoJwt,
            Usuario = new UsuarioTokenViewModel
            { 
                Id = usuario.Id, 
                UserName = usuario.UserName!, 
                Email = usuario.Email! 
            }
        };
    }
}
