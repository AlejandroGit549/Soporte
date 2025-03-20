
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Soporte.Application.Contracts.Persistence;
using Soporte.Application.Models.Common;
using System.Net;

namespace Soporte.Application.Features.Estados.Commands.UpdateEstado;

public class UpdateEstadoCommandHandler : IRequestHandler<UpdateEstadoCommand, Response<bool>>
{
    private readonly ILogger<UpdateEstadoCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateEstadoCommandHandler(ILogger<UpdateEstadoCommandHandler> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<bool>> Handle(UpdateEstadoCommand request, CancellationToken cancellationToken)
    {
        var EstadoEntidad = await _unitOfWork.EstadoRespository.GetByIdAsync(request.Id);

        var result = await _unitOfWork.Complete();
        if (result <= 0)
        {
            _logger.LogError("No se inserto el record de Estado");
            throw new Exception("No se pudo insertar el record de Estado");
        }

        return new Response<bool>() { Data = result > 0, Message = $"Se creo correctamente el estado: {EstadoEntidad.Nombre}", Success = true, StatusCode = (short)HttpStatusCode.OK };
    }
}
