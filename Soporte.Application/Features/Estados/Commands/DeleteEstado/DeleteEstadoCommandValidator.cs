

using FluentValidation;

namespace Soporte.Application.Features.Estados.Commands.DeleteEstado;

public class DeleteEstadoCommandValidator : AbstractValidator<DeleteEstadoCommand>
{
    public DeleteEstadoCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotNull().WithMessage("{Id} no puede ser nulo")
            .NotEmpty().WithMessage("{Id} no puede ser vacios");
    }
}
