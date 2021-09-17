namespace COVID19Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "Department_DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_DepartmentId" });
            RenameColumn(table: "dbo.Employee", name: "Department_DepartmentId", newName: "DepartmentId");
            AlterColumn("dbo.Employee", "DepartmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.HealthStatus", "Comorbidities", c => c.String(nullable: false));
            CreateIndex("dbo.Employee", "DepartmentId");
            AddForeignKey("dbo.Employee", "DepartmentId", "dbo.Department", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            AlterColumn("dbo.HealthStatus", "Comorbidities", c => c.String());
            AlterColumn("dbo.Employee", "DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.Employee", name: "DepartmentId", newName: "Department_DepartmentId");
            CreateIndex("dbo.Employee", "Department_DepartmentId");
            AddForeignKey("dbo.Employee", "Department_DepartmentId", "dbo.Department", "DepartmentId");
        }
    }
}
