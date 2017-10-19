namespace WorkForce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestructEmployees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Departments", new[] { "Employee_EmployeeId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
