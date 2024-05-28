using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PicPay.Infrasctructure.Client.Interfaces.Services;
using PicPay.Infrasctructure.Client.Services;
using PicPay.Infrasctructure.Database;
using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Infrasctructure.IoC
{
    public static class InfraModules
    {
        public static void AddInfraModules(this IServiceCollection services)
        {

            services.AddAuthentication(IdentityConstants.ApplicationScheme)
                    .AddCookie(IdentityConstants.ApplicationScheme)
                    .AddBearerToken(IdentityConstants.BearerScheme);

            services.AddAuthorization();

            services.AddHttpContextAccessor();

            services.AddIdentityCore<User>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddApiEndpoints();

            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<IHttpClientService, HttpClientService>();
        }
    }
}
