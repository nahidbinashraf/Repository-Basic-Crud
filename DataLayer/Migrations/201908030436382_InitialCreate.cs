namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonalInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnglishName = c.String(),
                        BanglaName = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalInformations", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.PersonalInformations", new[] { "DepartmentId" });
            DropTable("dbo.PersonalInformations");
            DropTable("dbo.Departments");
        }
    }
}
