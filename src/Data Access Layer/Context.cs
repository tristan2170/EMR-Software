using Mock_EMR_Software.Models;
using Microsoft.EntityFrameworkCore;



namespace Mock_EMR_Software.DAL
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Documents> Comments { get; set; }

        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Documents>().ToTable("Comments");
            modelBuilder.Entity<Contacts>().ToTable("Contact Info");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<Addresses>().ToTable("Addresses");

            base.OnModelCreating(modelBuilder);
        }
    }

    

}