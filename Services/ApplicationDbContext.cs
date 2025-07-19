using CrudApiJwt.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiJwt.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }

}