using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteKeeper.Dominio.ModuloAutenticacao;
using NoteKeeper.WebApi.Identity;
using NoteKeeper.WebApi.ModuloAutenticacao;
using NoteKeeper.WebApi.ViewModels;

namespace NoteKeeper.WebApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly ServicoAutenticacao servicoAutenticacao;
    private readonly JsonWebTokenProvider jsonWebTokenProvider;
    private readonly IMapper mapeador;

    public AutenticacaoController(ServicoAutenticacao servicoAutenticacao, JsonWebTokenProvider jsonWebTokenProvider,IMapper mapeador)
    {
        this.servicoAutenticacao = servicoAutenticacao;
        this.jsonWebTokenProvider = jsonWebTokenProvider;
        this.mapeador = mapeador;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar(RegistrarUsuarioViewModel viewModel)
    {
        var usuario = mapeador.Map<Usuario>(viewModel);

        var usarioResult = await servicoAutenticacao.RegistrarAsync(usuario, viewModel.Password);
        if (usarioResult.IsFailed)            
            return BadRequest(usarioResult.Errors);

        var tokenViewModel = jsonWebTokenProvider.GerarTokenAcesso(usuario);

        return Ok(tokenViewModel);
    }

    [HttpPost("autenticar")]
    public async Task<IActionResult> Autenticar(AutenticarUsuarioViewModel viewModel)
    {
        var usuarioResult = await servicoAutenticacao.AutenticarAsync(viewModel.UserName, viewModel.Password);

        if (usuarioResult.IsFailed)
            return BadRequest(usuarioResult.Errors);

        var usuario = usuarioResult.Value;

        var tokenViewModel = jsonWebTokenProvider.GerarTokenAcesso(usuario);

        return Ok(tokenViewModel);
    }

    [HttpPost("sair")]
    [Authorize]
    public async Task<IActionResult> Sair()
    {
        await servicoAutenticacao.SairAsync();

        return Ok();
    }
}
