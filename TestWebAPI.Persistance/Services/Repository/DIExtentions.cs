using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Persistance.Services.Repository.Abstraction;
using TestWebAPI.Persistance.Services.Repository.Implementation;

namespace TestWebAPI.Persistance.Services.Repository
{
    public static class DIExtentions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, DbContextOptions<ApplicationContext> options)
        {
            var context = new ApplicationContext(options);

            var constructorUserRepo = typeof(UserRepository).GetConstructor(new[] { typeof(ApplicationContext) });
            if (constructorUserRepo != null )
                throw new ArgumentNullException(nameof(constructorUserRepo));

            var constructorPictureRepo = typeof(PictureRepository).GetConstructor(new[] { typeof(ApplicationContext) });
            if (constructorPictureRepo != null)
                throw new ArgumentNullException(nameof(constructorPictureRepo));

            var constructorFriendshipsRepo = typeof(FriendshipsRepository).GetConstructor(new[] { typeof(ApplicationContext) });
            if (constructorFriendshipsRepo != null)
                throw new ArgumentNullException(nameof(constructorFriendshipsRepo));

            services.AddTransient<IUserRepository, UserRepository>(provider 
                => (UserRepository)constructorUserRepo.Invoke(new[] { context }));

            services.AddTransient<IPictureRepository, PictureRepository>(provider
                => (PictureRepository)constructorPictureRepo.Invoke(new[] { context }));

            services.AddTransient<IFriendshipRepository, FriendshipsRepository>(provider
                => (FriendshipsRepository)constructorFriendshipsRepo.Invoke(new[] { context }));

            return services;
        }

        public static IServiceCollection AddMSSQL(this IServiceCollection services, string connectionString)
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(connectionString).Options;
            services.AddRepository(options);

            return services;
        }
    }
}
