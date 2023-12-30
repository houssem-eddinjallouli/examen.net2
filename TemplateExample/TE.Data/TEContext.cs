using Microsoft.EntityFrameworkCore;
using TE.Core.Domain;
using TE.Data.config;

namespace TE.Data
{
    public class TEContext:DbContext
    {
        //DbSet<Sprint> sprint {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog = basetest2; 
                                        Integrated Security = true");
            optionsBuilder.UseLazyLoadingProxies(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new TacheConfig());
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

            configurationBuilder.Properties<string>().HaveMaxLength(200);
        }

    }
}