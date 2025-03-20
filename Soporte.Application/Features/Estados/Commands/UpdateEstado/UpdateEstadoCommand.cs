

using MediatR;
using Soporte.Application.Models.Common;

namespace Soporte.Application.Features.Estados.Commands.UpdateEstado;

public class UpdateEstadoCommand : IRequest<Response<bool>>
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public int ModificadoPor { get; set; }
}
