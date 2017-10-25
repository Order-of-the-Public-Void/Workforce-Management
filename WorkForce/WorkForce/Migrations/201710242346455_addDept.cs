namespace WorkForce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Department_DepartmentId", c => c.Int());
            CreateIndex("dbo.Employees", "Department_DepartmentId");
            AddForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_DepartmentId" });
            DropColumn("dbo.Employees", "Department_DepartmentId");
        }
    }
}
