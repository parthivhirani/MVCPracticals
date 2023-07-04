namespace MVCPractical13_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DesignationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DOB = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false, maxLength: 10),
                        Address = c.String(maxLength: 100),
                        Salary = c.Double(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DesignationModels", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeModels", "DesignationId", "dbo.DesignationModels");
            DropIndex("dbo.EmployeeModels", new[] { "DesignationId" });
            DropTable("dbo.EmployeeModels");
            DropTable("dbo.DesignationModels");
        }
    }
}
