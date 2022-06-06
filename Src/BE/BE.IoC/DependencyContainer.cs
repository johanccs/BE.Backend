using BE.Common.ActionFilters;
using BE.Common.Helpers;
using BE.Contracts;
using BE.Data.DbCtx;
using BE.Infrastructure.Logging;
using BE.Infrastructure.Notification;
using BE.Infrastructure.Notification.Classes;
using BE.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BE.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services, Config config)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<IPasswordHelper, PasswordHelper>();
            services.AddScoped<IProdService, ProductService>();
            services.AddScoped<INotificationService<EmailMessage>>
                (x => new EmailService(config));
            services.AddScoped<ICartService, CartService>();
           services.AddScoped<ILoggerService, LoggerService>();
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

