using Microsoft.Extensions.DependencyInjection;
using PicPay.Core.Users.Interfaces.Repositories;
using PicPay.Core.Users.Repositories;
using PicPay.Core.Users.Services;
using PicPay.Core.Users.Interfaces.Services;
using PicPay.Core.Transfers.Interfaces.Repositories;
using PicPay.Core.Transfers.Repositories;
using PicPay.Core.Transfers.Services;
using PicPay.Core.Transfers.Interfaces.Services;
using PicPay.Core.Accounts.Interfaces.Repositories;
using PicPay.Core.Accounts.Interfaces.Services;
using PicPay.Core.Accounts.Repositories;
using PicPay.Core.Accounts.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace PicPay.Core.IoC
{
    public static class CoreModules
    {
        public static void AddCoreModules(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddScoped<ITransfersRepository, TransfersRepository>();
            services.AddScoped<ITransfersService, TransfersService>();

            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<IAccountsService, AccountsService>();
        }
    }
}
