namespace WorkForce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class computer32 : DbMigration
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
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        TrainingId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDay = c.DateTime(nullable: false),
                        EndDay = c.DateTime(nullable: false),
                        MaxAttendees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainingId);
            
            CreateTable(
                "dbo.TrainingEmployees",
                c => new
                    {
                        Training_TrainingId = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Training_TrainingId, t.Employee_EmployeeId })
                .ForeignKey("dbo.Trainings", t => t.Training_TrainingId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Training_TrainingId)
                .Index(t => t.Employee_EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingEmployees", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.TrainingEmployees", "Training_TrainingId", "dbo.Trainings");
            DropForeignKey("dbo.Departments", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.TrainingEmployees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.TrainingEmployees", new[] { "Training_TrainingId" });
            DropIndex("dbo.Departments", new[] { "Employee_EmployeeId" });
            DropTable("dbo.TrainingEmployees");
            DropTable("dbo.Trainings");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.Computers");
        }
    }
}
