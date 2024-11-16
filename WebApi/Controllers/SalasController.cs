using Application.DTOs;
using Application.Handlers.Salas.Commands.Create;
using Application.Handlers.Salas.Queries.GetSalas;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/salas")]
    [ApiController]
    public class SalasController : ApiControllerBase
    {
        //[Authorize(Roles = "atendente")]
        [HttpGet]
        public async Task<ActionResult<PaginatedList<SalaDTO>>> Get([FromQuery] GetSalasQuery query) {
            return Ok(await Mediator.Send(query));
        }

        //[Authorize(Roles = "atendente")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSalaCommand command) {
            var result = await Mediator.Send(command);
            if (!result.Succeeded) {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
