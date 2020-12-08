using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using PatientPortalApplication.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace PatientPortalApplication.DAL
{
    public class Context: DbContext
    {
        public Context() : base("Context")
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Comments> Comments { get; set; }

        public DbSet<Prescrips> Prescrips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    

}