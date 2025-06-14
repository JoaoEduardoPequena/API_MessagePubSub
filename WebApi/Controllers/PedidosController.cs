using Application.Features.UseCases.Pedidos.Command.CriarPedido;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Tags("Pedidos")]
    [Route("api/pedido")]
    [ApiExplorerSettings(GroupName = "pedidos")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly ISender _sender;
        public PedidosController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        public async Task<IActionResult> CriarPedidos(CriarPedidoCommand request)
        {
            return Ok(await _sender.Send(request));
        }
    }
}
