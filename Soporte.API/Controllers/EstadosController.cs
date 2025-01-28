using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soporte.Application.Features.Estados.Commands.CreateEstado;
using Soporte.Application.Features.Estados.Queries.GetEstadosList;
using Soporte.Application.Models.Common;
using System.Net;

namespace Soporte.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstadosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("GetEstados")]
        [ProducesResponseType(typeof(Response<IEnumerable<EstadoVM>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response<IEnumerable<EstadoVM>>>> GetAccionesAll()
        {
            var query = new GetEstadosListQuery();
            var estados = await _mediator.Send(query);
            return Ok(estados);
        }

        [HttpPost, Route("CreateEstado")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response<int>>> CreateAccion([FromBody] CreateEstadoCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
