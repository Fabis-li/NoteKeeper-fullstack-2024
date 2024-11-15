using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteKeeper.WebApi.ModuloAutenticacao;

namespace NoteKeeper.WebApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly ServicoAutenticacao servicoAutenticacao;
    private readonly IMapper mapeador;

    public AutenticacaoController(ServicoAutenticacao servicoAutenticacao, IMapper mapeador)
    {
        this.servicoAutenticacao = servicoAutenticacao;
        this.mapeador = mapeador;
    }

    [HttpPost("sair")]
    public async Task<IActionResult> Sair()
    {
        await servicoAutenticacao.SairAsync();

        return Ok();
    }
}
