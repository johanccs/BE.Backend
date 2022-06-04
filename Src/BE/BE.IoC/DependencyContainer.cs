using BE.Contracts;
using BE.Services;
using CE.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BE.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<IProdService>(c=> new ProductService(settings.Url, settings.Api_Key));
            //services.AddScoped<ILoggerService, LoggerService>();
        }

        public static void RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatREntryPoint).Assembly);
        }
    }
}

