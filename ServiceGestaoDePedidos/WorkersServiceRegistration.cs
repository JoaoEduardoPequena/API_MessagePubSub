using Infrastruture.Worker;
using ServiceGestaoDePedidos.Woker.Interfaces;
using ServiceGestaoDePedidos.Woker.Process;

namespace ServiceGestaoDePedidos.Woker
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
