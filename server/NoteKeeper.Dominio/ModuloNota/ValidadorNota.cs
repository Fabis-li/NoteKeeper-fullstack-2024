using FluentValidation;

namespace NoteKeeper.Dominio.ModuloNota;

public class ValidadorNota : AbstractValidator<Nota>
{
    public ValidadorNota()
    {
        RuleFor(n => n.Titulo)
            .NotEmpty().WithMessage("O título é obrigatório")
            .MinimumLength(3).WithMessage("O título deve ter no mínimo 3 caracteres")
            .MaximumLength(30).WithMessage("O título deve ter no máximo 30 caracteres");

        RuleFor(n => n.Conteudo)
            .NotEmpty().WithMessage("O conteúdo é obrigatório")
            .MinimumLength(3).WithMessage("O conteúdo deve ter no mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("O conteúdo deve ter no máximo 100 caracteres");       
    }

}
