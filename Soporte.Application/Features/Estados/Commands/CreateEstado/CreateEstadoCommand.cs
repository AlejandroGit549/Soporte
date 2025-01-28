

using MediatR;
using Soporte.Application.Models.Common;

namespace Soporte.Application.Features.Estados.Commands.CreateEstado;

public class CreateEstadoCommand : IRequest<Response<int>>
{
    public required string Nombre { get; set; }
    public required int CreadoPor { get; set; }
}
