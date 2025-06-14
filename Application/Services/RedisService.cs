using Application.Interfaces;
using Application.Setting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Application.Services
{
    public class RedisService : IRedisService
    {
        private readonly RedisSetting _redisSetting;
        private readonly ISubscriber _subscriber;
        private readonly IConnectionMultiplexer _connection;
        public RedisService(IConnectionMultiplexer connection, IOptions<RedisSetting> redisSetting)
        {
            _connection = connection;
            _redisSetting = redisSetting.Value;
            _subscriber = _connection.GetSubscriber();
        }

        private string GetCacheKey(string key)
        {
            return $"{_redisSetting.ApiPedidosRestaurente}:{key}";
        }

        public async Task<bool> PublishAsync<T>(string channel, T message)
        {
            string _channel = GetCacheKey(channel);
            var dto=JsonConvert.SerializeObject(message);
            var result=await _subscriber.PublishAsync(_channel,dto);
            return result>=1 ? true : false;
        }
    }
}
