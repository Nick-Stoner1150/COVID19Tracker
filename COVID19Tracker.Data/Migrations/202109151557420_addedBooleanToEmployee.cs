namespace COVID19Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBooleanToEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            RenameColumn(table: "dbo.Employee", name: "DepartmentId", newName: "Department_DepartmentId");
            AlterColumn("dbo.Employee", "Department_DepartmentId", c => c.Int());
            CreateIndex("dbo.Employee", "Department_DepartmentId");
            AddForeignKey("dbo.Employee", "Department_DepartmentId", "dbo.Department", "DepartmentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Department_DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_DepartmentId" });
            AlterColumn("dbo.Employee", "Department_DepartmentId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Employee", name: "Department_DepartmentId", newName: "DepartmentId");
            CreateIndex("dbo.Employee", "DepartmentId");
            AddForeignKey("dbo.Employee", "DepartmentId", "dbo.Department", "DepartmentId", cascadeDelete: true);
        }
    }
}
