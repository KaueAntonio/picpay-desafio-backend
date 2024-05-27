using Microsoft.Extensions.DependencyInjection;
using PicPay.Core.Users.Interfaces.Repositories;
using PicPay.Core.Users.Repositories;
using PicPay.Core.Users.Services;
using PicPay.Core.Users.Interfaces.Services;
using PicPay.Core.Transfers.Interfaces.Repositories;
using PicPay.Core.Transfers.Repositories;
using PicPay.Core.Transfers.Services;
using PicPay.Core.Transfers.Interfaces.Services;

namespace PicPay.Core.IoC
{
    public static class CoreModules
    {
        public static void AddCoreModules(IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddScoped<ITransfersRepository, TransfersRepository>();
            services.AddScoped<ITransfersService, TransfersService>();
        }
    }
}
