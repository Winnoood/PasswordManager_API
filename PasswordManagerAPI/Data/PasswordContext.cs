using Microsoft.EntityFrameworkCore;
using PasswordManagerAPI.Models;

namespace PasswordManagerAPI.Data
{
    public class PasswordContext:DbContext
    {
        public PasswordContext(DbContextOptions<PasswordContext> options)
            : base(options)
        { }

        public DbSet<Password> Passwords { get; set; }
    }
}
