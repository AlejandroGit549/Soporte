
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Soporte.Application.Contracts.Persistence;
using Soporte.Application.Exceptions;
using Soporte.Application.Models.Common;
using System.IO;
using System.Net;

namespace Soporte.Application.Features.Estados.Commands.DeleteEstado;

public class DeleteEstadoCommandHandler : IRequestHandler<DeleteEstadoCommand, Response<bool>>
{
    private readonly ILogger<DeleteEstadoCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteEstadoCommandHandler(ILogger<DeleteEstadoCommandHandler> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<bool>> Handle(DeleteEstadoCommand request, CancellationToken cancellationToken)
    {
        var entidadEstado = await _unitOfWork.EstadoRespository.GetByIdAsync(request.Id);
        if (entidadEstado is null)
        {
            _logger.LogError($"{request.Id} estado no existe en el sistema");
            throw new NotFoundException(nameof(entidadEstado), request.Id);
        }
        entidadEstado.Activo = false;
        entidadEstado.ModificadoPor = request.EliminadoPor;
        entidadEstado.FechaModificacion = DateTime.Now;

        await _unitOfWork.EstadoRespository.UpdateAsync(entidadEstado);

        var response = await _unitOfWork.Complete();

        if (response == 0)
            return new Response<bool>() { Data = (response == 0), Message = "No se pudo eliminar el record de Estado.", Success = false, StatusCode = (short)HttpStatusCode.NotModified };

        return new Response<bool>() { Data = (response > 0), Message = $"Estado {entidadEstado.Id} fue Eliminado existosamente.", Success = true, StatusCode = (short)HttpStatusCode.OK };
    }
}
