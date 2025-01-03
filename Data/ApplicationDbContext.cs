using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {   
        }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<AddProject> AddProject { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Skills> Skills { get; set; }
    }
}
