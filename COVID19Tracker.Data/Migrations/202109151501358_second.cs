namespace COVID19Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        DepartmentLocation = c.String(),
                        LastCleanDate = c.DateTime(nullable: false),
                        WeeklyTests = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BadgeId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        HealthStatusId = c.Int(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.HealthStatus", t => t.HealthStatusId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.HealthStatusId);
            
            CreateTable(
                "dbo.HealthStatus",
                c => new
                    {
                        HealthStatusId = c.Int(nullable: false, identity: true),
                        Vaccinated = c.Boolean(nullable: false),
                        HasCovid = c.Boolean(nullable: false),
                        Hospitalized = c.Boolean(nullable: false),
                        Comorbidities = c.String(),
                        QuarantinedDate = c.DateTime(nullable: false),
                        LastTestedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HealthStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "HealthStatusId", "dbo.HealthStatus");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "HealthStatusId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropTable("dbo.HealthStatus");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
