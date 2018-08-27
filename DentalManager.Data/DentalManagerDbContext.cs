namespace DentalManager.Web.Data
{
    using DentalManager.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DentalManagerDbContext : IdentityDbContext
    {
        public DbSet<Patient> Patients { get; set;}

        public DbSet<Arrangment> Arrangments { get; set; }

        public DbSet<Manipulation> Manipulations { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DentalManagerDbContext(DbContextOptions<DentalManagerDbContext> options)
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);            
        }
    }
}
