using Microsoft.EntityFrameworkCore;

namespace portfolioApi.Models
{
    public class portfolioApiContext : DbContext
    {
        public portfolioApiContext (DbContextOptions<portfolioApiContext> options)
            : base(options)
            {
              
            }

        public DbSet<information> information { get; set; }
        public DbSet<eventModel> eventModel { get; set; }
        public DbSet<project> project { get; set; }
        public DbSet<skill> skill { get; set; }
        public DbSet<uriModel> uriModel { get; set; }

    }
}