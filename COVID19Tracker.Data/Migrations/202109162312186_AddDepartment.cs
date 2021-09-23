namespace COVID19Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Department", "LastCleanDate", c => c.DateTime());
            AlterColumn("dbo.HealthStatus", "Comorbidities", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HealthStatus", "Comorbidities", c => c.String());
            AlterColumn("dbo.Department", "LastCleanDate", c => c.DateTime(nullable: false));
        }
    }
}
