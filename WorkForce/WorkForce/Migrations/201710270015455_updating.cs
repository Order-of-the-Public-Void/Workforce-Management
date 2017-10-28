namespace WorkForce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        ComputerId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Manufacturer = c.String(),
                        Make = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ComputerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Computers");
        }
    }
}
