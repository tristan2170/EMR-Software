namespace PatientPortalApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PatientPortalApplication.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PatientPortalApplication.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PatientPortalApplication.DAL.Context";
        }

        protected override void Seed(PatientPortalApplication.DAL.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //context.Patients.AddOrUpdate
            //(x => x.patientId, new Patient { first_name = "John", last_name = "Sam", date_admitted = new DateTime(2020, 12, 6, 16, 30, 0) });


            //context.Comments.AddOrUpdate
            //(x => x.patientId, new Comments { comment = "Patient's only allowed to drink thickened water", date = new DateTime(2020, 12, 8, 08, 00, 0) });


            //context.Prescrips.AddOrUpdate
            //(x => x.patientId, new Prescrips { prescriptions = "Xanax 5mg" });
        }
    }
}
