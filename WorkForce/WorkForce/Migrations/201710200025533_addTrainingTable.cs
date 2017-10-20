namespace WorkForce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTrainingTable : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.TrainingEmployees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.TrainingEmployees", new[] { "Training_TrainingId" });
            DropTable("dbo.TrainingEmployees");
            DropTable("dbo.Trainings");
        }
    }
}
