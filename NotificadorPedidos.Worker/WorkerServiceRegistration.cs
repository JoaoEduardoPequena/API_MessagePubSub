using Infrastruture.Worker;
using NotificadorPedidos.Worker.Interfaces;
using NotificadorPedidos.Worker.Process;

namespace NotificadorPedidos.Worker
{
    public static class WorkerServiceRegistration
    {
        public static void AddNotificadorPedidosWorker(this IServiceCollection services, IConfiguration config)
        {
            services.AddInfrastructureWorker(config);
            services.AddSingleton<ISubscribeMessageProcess, SubscribeMessageProcess>();
        }
    }
}
