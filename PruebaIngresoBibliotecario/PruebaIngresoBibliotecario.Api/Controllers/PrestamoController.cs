using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Commands;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Queries.GetPrestamoById;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Queries.GetPrestamoByUser;
using PruebaIngresoBibliotecario.Application.Features.Prestamos.Vm;
using PruebaIngresoBibliotecario.Domain.Enums;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {

        private readonly IMediator Mediator;

        public PrestamoController(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        [HttpGet("{idPrestamo}")]
        [ProducesResponseType(typeof(PrestamoVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PrestamoVm>> Index(Guid idPrestamo)
        {
            GetPrestamoQuery query = new GetPrestamoQuery(idPrestamo);
            PrestamoVm response = await this.Mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreatePrestamoVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePrestamoVm>> Index([FromBody] CreatePrestamoCommand request)
        {
            if (request.TipoUsuario == UserType.INVITADO)
            {
                GetPrestamoByUserQuery query = new GetPrestamoByUserQuery(request.IdentificacionUsuario);
                await this.Mediator.Send(query);
            }

            return await this.Mediator.Send(request);
        }
    }
}
