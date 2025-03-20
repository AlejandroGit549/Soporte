using MediatR;
using Soporte.Application.Models.Common;

namespace Soporte.Application.Features.Estados.Commands.DeleteEstado;

public class DeleteEstadoCommand : IRequest<Response<bool>>
{
    public int Id { get; set; }
    public int EliminadoPor { get; set; }
}
