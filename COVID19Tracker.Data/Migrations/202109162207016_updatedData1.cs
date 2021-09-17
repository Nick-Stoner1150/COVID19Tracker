namespace COVID19Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedData1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Department", "LastCleanDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Department", "LastCleanDate", c => c.DateTime(nullable: false));
        }
    }
}
