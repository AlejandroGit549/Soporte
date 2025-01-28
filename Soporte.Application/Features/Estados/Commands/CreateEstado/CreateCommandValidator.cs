
using FluentValidation;

namespace Soporte.Application.Features.Estados.Commands.CreateEstado;

public class CreateCommandValidator : AbstractValidator<CreateEstadoCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(p => p.Nombre)
            .NotNull().WithMessage("{Nombre} no puede ser nulo")
            .NotEmpty().WithMessage("{Nombre} no puede ser vacios");
        RuleFor(p => p.CreadoPor)
           .NotNull().WithMessage("{CreadoPor} no puede ser nulo")
           .NotEmpty().WithMessage("{CreadoPor} no puede ser vacios"); ;
    }
}
