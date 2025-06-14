namespace Application.Interfaces
{
    public interface IRedisService
    {
        public Task<bool> PublishAsync<T>(string channel, T message);
    }
}
