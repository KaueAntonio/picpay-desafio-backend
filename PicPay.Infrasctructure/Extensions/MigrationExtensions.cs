using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PicPay.Infrasctructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PicPay.Infrasctructure.Database.Models;

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

        public static async Task ApplyUserRoles(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            var services = scope.ServiceProvider;
            var userManager = services.GetRequiredService<UserManager<User>>();

            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedRoles(services);
        }

        private static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = ["Default", "Lojista"];
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

    }
}
