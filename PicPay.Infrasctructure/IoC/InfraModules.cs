using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PicPay.Infrasctructure.Database;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Infrasctructure.IoC
{
    public static class InfraModules
    {
        public static void AddInfraModules(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthorization();
            services.AddAuthentication()
                    .AddCookie(IdentityConstants.ApplicationScheme)
                    .AddBearerToken(IdentityConstants.BearerScheme);
        }
    }
}
