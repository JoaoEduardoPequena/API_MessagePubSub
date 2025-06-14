namespace Infrastruture.Worker.Interfaces
{
    public interface IRedisService
    {
        public void Subscribe<T>(string channel, Action<T> handler);
    }
}
