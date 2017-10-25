namespace WorkForce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDept : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Departments", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.Departments", "Employee_EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "Employee_EmployeeId", c => c.Int());
            CreateIndex("dbo.Departments", "Employee_EmployeeId");
            AddForeignKey("dbo.Departments", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
