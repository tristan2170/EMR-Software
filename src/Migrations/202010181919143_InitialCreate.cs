namespace PatientPortalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Builders;


    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.comments",
                c => new
                    {
                        commentId = c.Int(nullable: false, identity: true),
                        comment = c.String(),
                        date = c.DateTime(nullable: false),
                        patientid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.commentId)
                .ForeignKey("dbo.patient", t => t.patientid, cascadeDelete: true)
                .Index(t => t.patientid);
            
            CreateTable(
                "dbo.patient",
                c => new
                    {
                        patientId = c.Int(nullable: false, identity: true),
                        first_name = c.String(),
                        last_name = c.String(),
                        date_admitted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.patientId);
            
            CreateTable(
                "dbo.prescriptions",
                c => new
                    {
                        prescripId = c.Int(nullable: false, identity: true),
                        prescriptions = c.String(),
                        patientid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.prescripId)
                .ForeignKey("dbo.patient", t => t.patientid, cascadeDelete: true)
                .Index(t => t.patientid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.comments", "patientid", "dbo.patient");
            DropForeignKey("dbo.prescriptions", "patientid", "dbo.patientr");
            DropIndex("dbo.prescriptions", new[] { "patientid" });
            DropIndex("dbo.comments", new[] { "patientid" });
            DropTable("dbo.prescriptions");
            DropTable("dbo.patient");
            DropTable("dbo.comments");
        }
    }
}
