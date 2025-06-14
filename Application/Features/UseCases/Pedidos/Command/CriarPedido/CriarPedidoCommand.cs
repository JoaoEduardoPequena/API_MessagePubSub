using MediatR;

namespace Application.Features.UseCases.Pedidos.Command.CriarPedido
{
    public record CriarPedidoCommand
    (
        string NomeCliente,
        string EmailCliente,
        string DescricaoPedido
    ) :IRequest<bool>;
}
