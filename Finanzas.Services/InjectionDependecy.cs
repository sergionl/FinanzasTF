using Finanzas.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finanzas.Services
{
    public static class InjectionDependecy
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            return services.AddScoped<IUserRepository, UserRepository>()
                .AddTransient<IUserService, UserService>()
                .AddScoped<IBonoRepository, BonoRepository>()
                .AddTransient<IBonoService, BonoService>();
                //.AddScoped<IUserBonoRepository, UserBonoRepository>()
                //.AddTransient<IUserBonoService, UserBonoService>();
                
        }
    }
}
