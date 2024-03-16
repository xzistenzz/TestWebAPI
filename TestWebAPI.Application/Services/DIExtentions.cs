using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Application.Services.Abstraction;
using TestWebAPI.Application.Services.Implementation;

namespace TestWebAPI.Application.Services
{
    public static class DIExtentions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IHashPassword, HashPassword>();
            services.AddTransient<IPictureService, PictureService>();

            return services;
        }
    }
}
