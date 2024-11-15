using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteKeeper.Aplicacao.ModuloNota;
using NoteKeeper.Dominio.ModuloNota;
using NoteKeeper.WebApi.ViewModels;

namespace NoteKeeper.WebApi.Controllers;

[Route("api/notas")]
[ApiController]
[Authorize]
public class NotaController(ServicoNota notaService, IMapper mapeador) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(bool? arquivadas)
    {
        Result<List<Nota>> notasResult;

        if (arquivadas.HasValue)
            notasResult = await notaService.Filtrar(n => n.Arquivada == arquivadas);
        else
            notasResult = await notaService.SelecionarTodosAsync();
        
        var viewNodel = mapeador.Map<ListarNotaViewModel[]>(notasResult.Value);

        return Ok(viewNodel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var notaResult = await notaService.SelecionarPorIdAsync(id);           

        if (notaResult.IsSuccess && notaResult.Value is null)
            return NotFound(notaResult.Errors);

        var viewModel = mapeador.Map<VisualizarNotaViewModel>(notaResult.Value);

        return Ok(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InserirNotaViewModel notaVm)
    {
        var nota = mapeador.Map<Nota>(notaVm);

        var resultado = await notaService.InserirAsync(nota);

        if (resultado.IsFailed)
            return BadRequest(resultado.Errors.Select(err => err.Message));

        return Ok(notaVm);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, EditarNotaViewModel notaVm)
    {
        var notaSelecionada = await notaService.SelecionarPorIdAsync(id);

        if (notaSelecionada.IsFailed)
            return BadRequest(notaSelecionada.Value);

        if (notaSelecionada.IsSuccess && notaSelecionada.Value is null)
            return NotFound(notaSelecionada.Errors);

        var notaEditada = mapeador.Map(notaVm, notaSelecionada.Value);

        var resultado = await notaService.EditarAsync(notaEditada);

       if(resultado.IsFailed)
            return BadRequest(resultado.Errors.Select(err => err.Message));
        

        return Ok(notaVm);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var resultado = await notaService.ExcluirAsync(id);

        if (resultado.IsFailed)
            return BadRequest(resultado.Errors);

        return Ok();
    }

    [HttpPut("{id}/alterar-status/")]
    public async Task<IActionResult>AlterarStatus(Guid id)
    {
        var notaResult = await notaService.SelecionarPorIdAsync(id);

        if(notaResult.IsFailed)
            return StatusCode(500);

        if(notaResult.IsSuccess && notaResult.Value is null)
            return NotFound(notaResult.Errors);

        var edicaoResult =  notaService.AlterarStatus(notaResult.Value);

        if (edicaoResult.IsFailed)
            return BadRequest(edicaoResult.Errors);

        var notaVm = mapeador.Map<VisualizarNotaViewModel>(edicaoResult.Value);

        return Ok(notaVm);
    }

}
