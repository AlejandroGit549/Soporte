
using AutoMapper;
using MediatR;
using Soporte.Application.Contracts.Persistence;
using Soporte.Application.Exceptions;
using Soporte.Application.Models.Common;
using Soporte.Domain;
using System.Net;


namespace Soporte.Application.Features.Estados.Queries.GetEstadosList;

public class GetEstadosListQueryHandler : IRequestHandler<GetEstadosListQuery, Response<List<EstadoVM>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEstadosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<List<EstadoVM>>> Handle(GetEstadosListQuery request, CancellationToken cancellationToken)
    {
        var estadosList = await _unitOfWork.Repository<Estado>().GetAsync(p => p.Activo == true);
        var estadosVM = Getlist(estadosList.ToList());
        if (estadosVM.Any())
            return new Response<List<EstadoVM>> { Data = estadosVM.ToList(), Success = false, Message = "No se encontro información.", StatusCode = (short)HttpStatusCode.OK };

        return new Response<List<EstadoVM>> { Data = estadosVM.ToList(), Success = false, Message = "Éxito al obtener información.", StatusCode = (short)HttpStatusCode.OK };
    }

    private IEnumerable<EstadoVM> Getlist(IEnumerable<Estado> estados)
    {
        foreach (Estado estado in estados)
        {
            yield return new EstadoVM()
            {
                Id = estado.Id,
                Nombre = estado.Nombre,
                Activo = estado.Activo,
                CreadoPor = estado.CreadoPor,
                FechaCreacion = estado.FechaCreacion,
                ModificadoPor = estado.ModificadoPor,
                FechaModificacion = estado.FechaModificacion
            };
        }

    }
}
