using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soporte.Application.Features.Estados.Queries.GetEstadosList;
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
        [ProducesResponseType(typeof(IEnumerable<EstadoVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EstadoVM>>> GetAccionesAll()
        {
            var query = new GetEstadosListQuery();
            var estados = await _mediator.Send(query);
            return Ok(estados);
        }
    }
}
