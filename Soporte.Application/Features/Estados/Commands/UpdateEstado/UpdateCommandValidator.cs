

using FluentValidation;

namespace Soporte.Application.Features.Estados.Commands.UpdateEstado;

public class UpdateCommandValidator : AbstractValidator<UpdateEstadoCommand>
{
    public UpdateCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotNull().WithMessage("{Id} no puede ser nulo")
            .NotEmpty().WithMessage("{Id} no puede ser vacios");
        RuleFor(p => p.Nombre)
            .NotNull().WithMessage("{Nombre} no puede ser nulo")
            .NotEmpty().WithMessage("{Nombre} no puede ser vacios");
    }
}
