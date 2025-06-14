using Infrastruture.Worker.Interfaces;
using Infrastruture.Worker.Setting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Infrastruture.Worker.Services
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

        public void Subscribe<T>(string channel, Action<T> handler)
        {
            string _Channel = GetCacheKey(channel);
            _subscriber.Subscribe(_Channel, (redisChannel, redisMessage) =>
            {
                var data = JsonConvert.DeserializeObject<T>(redisMessage);
                handler?.Invoke(data);
            });
        }
    }
}
