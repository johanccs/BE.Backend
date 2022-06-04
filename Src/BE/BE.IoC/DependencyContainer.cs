using BE.Common.ActionFilters;
using BE.Common.Helpers;
using BE.Contracts;
using BE.Data.DbCtx;
using BE.Services;
using CE.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BE.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<IPasswordHelper, PasswordHelper>();
            //services.AddScoped<IProdService>(c=> new ProductService(settings.Url, settings.Api_Key));
            //services.AddScoped<ILoggerService, LoggerService>();
        }

        public static void RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatREntryPoint).Assembly);
        }

        public static void RegisterDBContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(
                opt=> opt.UseSqlServer(config.GetConnectionString("sqlConnection")));
        }
    }
}

