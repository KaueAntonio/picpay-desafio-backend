using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PicPay.Infrasctructure.Database;

namespace PicPay.Infrasctructure.IoC
{
    public static class InfraModules
    {
        public static void AddInfraModules(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>();
        }
    }
}
