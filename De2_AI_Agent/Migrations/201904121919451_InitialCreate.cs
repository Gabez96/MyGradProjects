namespace De2_AI_Agent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccomodationOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        phoneNumber = c.Int(nullable: false),
                        UsersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UsersId, cascadeDelete: true)
                .Index(t => t.UsersId);
            
            CreateTable(
                "dbo.StudentAccomodations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        location = c.String(),
                        IncomeGroup = c.String(),
                        UsersId = c.Int(nullable: false),
                        AccomodationOwner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccomodationOwners", t => t.AccomodationOwner_Id)
                .Index(t => t.AccomodationOwner_Id);
            
            CreateTable(
                "dbo.Raters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        service = c.Int(nullable: false),
                        safety = c.Int(nullable: false),
                        UsersId = c.Int(nullable: false),
                        StudentAccomodationId = c.Int(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentAccomodations", t => t.StudentAccomodationId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UsersId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.UsersId)
                .Index(t => t.StudentAccomodationId)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        University = c.String(),
                        UsersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UsersId, cascadeDelete: true)
                .Index(t => t.UsersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "UsersId", "dbo.Users");
            DropForeignKey("dbo.Raters", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Raters", "UsersId", "dbo.Users");
            DropForeignKey("dbo.AccomodationOwners", "UsersId", "dbo.Users");
            DropForeignKey("dbo.Raters", "StudentAccomodationId", "dbo.StudentAccomodations");
            DropForeignKey("dbo.StudentAccomodations", "AccomodationOwner_Id", "dbo.AccomodationOwners");
            DropIndex("dbo.Students", new[] { "UsersId" });
            DropIndex("dbo.Raters", new[] { "Student_Id" });
            DropIndex("dbo.Raters", new[] { "StudentAccomodationId" });
            DropIndex("dbo.Raters", new[] { "UsersId" });
            DropIndex("dbo.StudentAccomodations", new[] { "AccomodationOwner_Id" });
            DropIndex("dbo.AccomodationOwners", new[] { "UsersId" });
            DropTable("dbo.Students");
            DropTable("dbo.Users");
            DropTable("dbo.Raters");
            DropTable("dbo.StudentAccomodations");
            DropTable("dbo.AccomodationOwners");
        }
    }
}
