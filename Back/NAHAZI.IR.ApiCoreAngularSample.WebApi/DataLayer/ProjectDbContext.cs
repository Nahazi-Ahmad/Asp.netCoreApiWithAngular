using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using NAHAZI.IR.ApiCoreAngularSample.WebApi.Model.DomainClasses;
using System.Diagnostics;

namespace NAHAZI.IR.ApiCoreAngularSample.WebApi.DataLayer
{
    public partial class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        {
        }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ProjectDbContext");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<User>().
                Property(e => e.UserName).HasMaxLength(200);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public DbSet<User> Users{ get; set; }
    }
}
