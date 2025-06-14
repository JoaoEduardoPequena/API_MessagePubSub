using Application.Behaviors;
using Application.Interfaces;
using Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Application.Setting;
using StackExchange.Redis;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration conf)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });
            services.Configure<RedisSetting>(op => conf.GetSection("RedisSetting").Bind(op));
            services.AddStackExchangeRedisCache(op => op.Configuration = conf["RedisSetting:ConnectionString"]);
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(conf["RedisSetting:ConnectionString"]));
            services.AddTransient<IRedisService, RedisService>();

            return services;
        }

    }
}
