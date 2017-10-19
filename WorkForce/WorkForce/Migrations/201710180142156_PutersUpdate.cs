namespace WorkForce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutersUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        ComputerId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComputerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Computers");
        }
    }
}
