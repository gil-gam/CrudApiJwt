using CrudApiJwt.Models;
using CrudApiJwt.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CrudApiJwt.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAdminUserAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var passwordHasher = new PasswordHasher<User>();

            if (!await context.Users.AnyAsync(u => u.Email == "admin@admin.com"))
            {
                var admin = new User
                {
                    Name = "Admin",
                    Email = "admin@admin.com",
                    Role = "Admin"
                };

                admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin@123");

                context.Users.Add(admin);
                await context.SaveChangesAsync();
            }
        }
    }
}
