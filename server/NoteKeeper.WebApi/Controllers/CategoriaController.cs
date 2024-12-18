﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteKeeper.Aplicacao.ModuloCategoria;
using NoteKeeper.Dominio.ModuloCategoria;
using NoteKeeper.WebApi.ViewModels;
using Serilog;

namespace NoteKeeper.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoriaController(ServicoCategoria servicoCategoria, IMapper mapeador) : ControllerBase
{
    private readonly ServicoCategoria servicoCategoria = servicoCategoria;
    private readonly IMapper mapeador = mapeador;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var reusltado = await servicoCategoria.SelecionarTodosAsync();            

        var viewModel = mapeador.Map<ListarCategoriaViewModel[]>(reusltado.Value);

        Log.Information("Foram selecionados {QuantidadeRegistros} registros", viewModel.Count());

        return Ok(reusltado.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var resultado = await servicoCategoria.SelecionarPorIdAsync(id);

        var viewModel = mapeador.Map<VisualizarCategoriaViewModel>(resultado.Value);

        return Ok(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Inserir(InserirCategoriaViewModel categoriaVm)
    {
        var categoria = mapeador.Map<Categoria>(categoriaVm);

        var resultado = await servicoCategoria.InserirAsync(categoria);

        if (resultado.IsFailed)

            return BadRequest(resultado.Errors);

        return Ok(categoriaVm);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Editar(Guid id, EditarCategoriaViewModel categoriaVm)
    {
        var categoriaSelecionada = await servicoCategoria.SelecionarPorIdAsync(id);            

        var categoria = mapeador.Map(categoriaVm, categoriaSelecionada.Value);

        var resultado = await servicoCategoria.EditarAsync(categoria);

        if (resultado.IsFailed)
            return BadRequest(resultado.Errors);

        return Ok(categoriaVm);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(Guid id)
    {
        var categoriaSelecionada = await servicoCategoria.SelecionarPorIdAsync(id);

        if (categoriaSelecionada.IsFailed)
            return NotFound(categoriaSelecionada.Errors);

        var resultado = await servicoCategoria.ExcluirAsync(id);

        if (resultado.IsFailed)
            return BadRequest(resultado.Errors);

        return Ok();
    }
}
