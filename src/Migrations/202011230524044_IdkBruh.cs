namespace PatientPortalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdkBruh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.patient", "Patient_patientId", c => c.Int());
            CreateIndex("dbo.patient", "Patient_patientId");
            AddForeignKey("dbo.patient", "Patient_patientId", "dbo.patient", "Patient Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.patient", "Patient_patientId", "dbo.patient");
            DropIndex("dbo.patient", new[] { "Patient_patientId" });
            DropColumn("dbo.patient", "Patient_patientId");
        }
    }
}
