namespace WorkForce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmpStartDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "StartDate");
        }
    }
}
