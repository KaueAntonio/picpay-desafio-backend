using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PicPay.Infrasctructure.Database;
using Microsoft.EntityFrameworkCore;

namespace PicPay.Infrasctructure.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();
        }
    }
}
