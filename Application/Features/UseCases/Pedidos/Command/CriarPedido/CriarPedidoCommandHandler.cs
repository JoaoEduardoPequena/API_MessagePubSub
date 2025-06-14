using FluentValidation;
using Mapster;
using MediatR;
using Domain.Entites;
using Domain.Interfaces;
using Application.Interfaces;
using Application.Setting;
using Microsoft.Extensions.Options;

namespace Application.Features.UseCases.Pedidos.Command.CriarPedido
{
    public class CriarPedidoCommandHandler : IRequestHandler<CriarPedidoCommand, bool>
    {
        private readonly IRepoPedido _repoPedido;
        private readonly IValidator<CriarPedidoCommand> _validator;
        private readonly IRedisService _redisService;
        private readonly RedisSetting _redisSetting;
        public CriarPedidoCommandHandler(IRepoPedido repoPedido, IValidator<CriarPedidoCommand> validator, IRedisService redisService, IOptions<RedisSetting> redisSetting)
        {
            _repoPedido = repoPedido;
            _validator = validator;
            _redisService = redisService;
            _redisSetting = redisSetting.Value;
        }

        public async Task<bool> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid) return false;
            var dto = request.Adapt<Pedido>();
            var result=await _repoPedido.CriarPedido(dto);
            await _redisService.PublishAsync(_redisSetting.Channel,dto);
            return result;
        }
    }
}
