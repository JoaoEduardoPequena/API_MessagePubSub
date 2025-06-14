using NotificadorPedidos.Worker.Interfaces;

namespace NotificadorPedidos.Worker.Workers
{
    public class SubscribeMessageWork : BackgroundService
    {
        private readonly ILogger<SubscribeMessageWork> _logger;
        private readonly ISubscribeMessageProcess _subscribeMessage;
        public SubscribeMessageWork(ISubscribeMessageProcess subscribeMessage, ILogger<SubscribeMessageWork> logger)
        {
            _subscribeMessage = subscribeMessage;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
               await _subscribeMessage.SubscribeMessageWork();
               await Task.Delay(TimeSpan.FromSeconds(25), stoppingToken);
            }
        }
    }
}
