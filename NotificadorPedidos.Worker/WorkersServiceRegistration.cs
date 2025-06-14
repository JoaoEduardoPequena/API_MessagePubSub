using Infrastruture.Worker;
using NotificadorPedidos.Worker.Interfaces;
using NotificadorPedidos.Worker.Process;

namespace NotificadorPedidos.Worker
{
    public static class WorkersServiceRegistration
    {
        public static void AddWorkersServiceGestaoPedidos(this IServiceCollection services, IConfiguration config)
        {
            services.AddInfrastructureWorker(config);
            services.AddSingleton<ISubscribeMessageProcess, SubscribeMessageProcess>();
        }
    }
}
