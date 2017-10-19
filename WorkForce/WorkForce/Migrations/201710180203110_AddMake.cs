namespace WorkForce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMake : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Computers", "Manufacturer", c => c.Int(nullable: false));
            AddColumn("dbo.Computers", "Make", c => c.Int(nullable: false));
            AddColumn("dbo.Computers", "PurchaseDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Computers", "PurchaseDate");
            DropColumn("dbo.Computers", "Make");
            DropColumn("dbo.Computers", "Manufacturer");
        }
    }
}
