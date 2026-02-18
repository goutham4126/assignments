using Microsoft.EntityFrameworkCore;
using RepoDemo.Models;

namespace RepoDemo.Data
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
