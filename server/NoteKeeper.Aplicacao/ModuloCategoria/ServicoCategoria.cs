using FluentResults;
using FluentValidation.Results;
using NoteKeeper.Dominio.ModuloCategoria;


namespace NoteKeeper.Aplicacao.ModuloCategoria;

public class ServicoCategoria
{
    private readonly IRepositorioCategoria _repositorioCategoria;

    public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
    {
        _repositorioCategoria = repositorioCategoria;
    }

    public async Task<Result<Categoria>> InserirAsync(Categoria categoria)
    {
        var validador = new ValidadorCategoria();

        var resultadoValidacao = await validador.ValidateAsync(categoria);   
        
        if(!resultadoValidacao.IsValid)
        {
            var erros = resultadoValidacao.Errors.Select(failure => failure.ErrorMessage).ToList();

            return Result.Fail(erros);
        }

        await _repositorioCategoria.InserirAsync(categoria);

        return Result.Ok(categoria);
    }

    public async Task<Result<Categoria>> EditarAsync(Categoria categoria)
    {
        var validador = new ValidadorCategoria();

        var resultadoValidacao = await validador.ValidateAsync(categoria);

        if (!resultadoValidacao.IsValid)
        {
            var erros = resultadoValidacao.Errors.Select(failure => failure.ErrorMessage).ToList();

            return Result.Fail(erros);
        }

        _repositorioCategoria.Editar(categoria);

        return Result.Ok(categoria);
    }

    public async Task<Result> ExcluirAsync(Guid id)
    {
        var categoria = await _repositorioCategoria.SelecionarPorIdAsync(id);

        if (categoria == null)
            return Result.Fail($"Categoria {id} não encontrada");

        _repositorioCategoria.Excluir(categoria);

        return Result.Ok();
    }

    public async Task<Result<List<Categoria>>> SelecionarTodosAsync()
    {
        var categorias = await _repositorioCategoria.SelecionarTodosAsync();

        return Result.Ok(categorias);
    }

    public async Task<Result<Categoria>> SelecionarPorIdAsync(Guid id)
    {
        var categoria = await _repositorioCategoria.SelecionarPorIdAsync(id);

        return Result.Ok(categoria);
    }
}