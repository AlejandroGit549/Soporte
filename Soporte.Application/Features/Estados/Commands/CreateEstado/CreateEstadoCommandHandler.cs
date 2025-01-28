using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Soporte.Application.Contracts.Persistence;
using Soporte.Application.Models.Common;
using Soporte.Domain;
using System;
using System.Net;

namespace Soporte.Application.Features.Estados.Commands.CreateEstado;

public class CreateEstadoCommandHandler : IRequestHandler<CreateEstadoCommand, Response<int>>
{
    private readonly ILogger<CreateEstadoCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEstadoCommandHandler(ILogger<CreateEstadoCommandHandler> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateEstadoCommand request, CancellationToken cancellationToken)
    {
        var estadoEntity = new Estado()
        {
            Nombre = request.Nombre,
            CreadoPor = request.CreadoPor,
            Activo = true,
            FechaCreacion = DateTime.Now
        };
        _unitOfWork.Repository<Estado>().AddEntity(estadoEntity);

        var result = await _unitOfWork.Complete();
        if(result <= 0)
        {
            _logger.LogError("No se inserto el record de Estado");
            throw new Exception("No se pudo insertar el record de Estado");
        }

        return new Response<int>() { Data = estadoEntity.Id, Message = $"Se creo correctamente el estado: {estadoEntity.Nombre}", Success = true, StatusCode = (short)HttpStatusCode.OK };
    }
}
