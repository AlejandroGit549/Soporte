
using MediatR;
using Soporte.Application.Models.Common;

namespace Soporte.Application.Features.Estados.Queries.GetEstadosList;

public class GetEstadosListQuery : IRequest<Response<List<EstadoVM>>>
{
}
