using FluentResults;
using NoteKeeper.Dominio.ModuloNota;

namespace NoteKeeper.Aplicacao.ModuloNota;

public class ServicoNota
{
    private readonly IRepositorioNota _repositorioNota;

    public ServicoNota(IRepositorioNota repositorioNota)
    {
        _repositorioNota = repositorioNota;
    }

    public async Task<Result<Nota>> InserirAsync(Nota nota)
    {
        var resultadoValidacao = nota.Validar();

        if (resultadoValidacao.Count > 0)
            return Result.Fail(resultadoValidacao);

        await _repositorioNota.InserirAsync(nota);

        return Result.Ok(nota);
    }

    public async Task<Result<Nota>> EditarAsync(Nota nota)
    {
        var resultadoValidacao = nota.Validar();

        if (resultadoValidacao.Count > 0)
            return Result.Fail(resultadoValidacao);

        _repositorioNota.Editar(nota);

        return Result.Ok(nota);
    }

    public async Task<Result<Nota>> ExcluirAsync(Guid id)
    {
        var nota = await _repositorioNota.SelecionarPorIdAsync(id);

        _repositorioNota.Excluir(nota);

        return Result.Ok();
    }

    public async Task<Result<List<Nota>>> SelecionarTodosAsync()
    {
        var notas = await _repositorioNota.SelecionarTodosAsync();

        return Result.Ok(notas);
    }

    public async Task<Result<Nota>> SelecionarPorIdAsync(Guid id)
    {
        var nota = await _repositorioNota.SelecionarPorIdAsync(id);

        return Result.Ok(nota);
    }
}