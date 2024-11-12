using FluentValidation;

namespace NoteKeeper.Dominio.ModuloCategoria;

public class ValidadorCategoria : AbstractValidator<Categoria>
{
    public ValidadorCategoria()
    {
        RuleFor(c => c.Titulo)
            .NotEmpty().WithMessage("O título é obrigatório")
            .MinimumLength(3).WithMessage("O título deve ter no mínino 3 caracteres")
            .MaximumLength(30).WithMessage("O título deve ter no máximo 30 caracteres");
    }
}
