namespace PatientPortalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.patient", "Patient_patientId", "dbo.patient");
            DropIndex("dbo.comments", new[] { "patientid" });
            DropIndex("dbo.patient", new[] { "Patient_patientId" });
            DropIndex("dbo.prescrips", new[] { "patientid" });
            RenameColumn(table: "dbo.comments", name: "commentId", newName: "Comment Id");
            RenameColumn(table: "dbo.comments", name: "date", newName: "Comment Date");
            RenameColumn(table: "dbo.comments", name: "comment", newName: "Comment");
            RenameColumn(table: "dbo.patient", name: "patientId", newName: "Patient Id");
            RenameColumn(table: "dbo.patient", name: "first_name", newName: "First Name");
            RenameColumn(table: "dbo.patient", name: "last_name", newName: "Last Name");
            RenameColumn(table: "dbo.patient", name: "date_admitted", newName: "Date Admitted");
            RenameColumn(table: "dbo.prescrips", name: "prescripId", newName: "Prescription Id");
            RenameColumn(table: "dbo.prescrips", name: "prescriptions", newName: "Prescription");
            CreateIndex("dbo.comments", "patientId");
            CreateIndex("dbo.prescrips", "patientId");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.patient", "Patient_patientId", c => c.Int());
            DropIndex("dbo.prescrips", new[] { "patientId" });
            DropIndex("dbo.comments", new[] { "patientId" });
            RenameColumn(table: "dbo.prescrips", name: "Prescription", newName: "prescriptions");
            RenameColumn(table: "dbo.prescrips", name: "Prescription Id", newName: "prescripId");
            RenameColumn(table: "dbo.patient", name: "Date Admitted", newName: "date_admitted");
            RenameColumn(table: "dbo.patient", name: "Last Name", newName: "last_name");
            RenameColumn(table: "dbo.patient", name: "First Name", newName: "first_name");
            RenameColumn(table: "dbo.patient", name: "Patient Id", newName: "patientId");
            RenameColumn(table: "dbo.comments", name: "Comment Date", newName: "date");
            RenameColumn(table: "dbo.comments", name: "Comment Id", newName: "commentId");
            CreateIndex("dbo.prescrips", "patientid");
            CreateIndex("dbo.patient", "Patient_patientId");
            CreateIndex("dbo.comments", "patientid");
            AddForeignKey("dbo.patient", "Patient_patientId", "dbo.patient", "patientId");
        }
    }
}
