using ServiceGestaoDePedidos.Woker;
using ServiceGestaoDePedidos.Woker.Workers;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWorkersServiceGestaoPedidos(builder.Configuration);
builder.Services.AddHostedService<SubscribeMessageWork>();

var host = builder.Build();
host.Run();
