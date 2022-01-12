namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComMediCa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                    })
                .PrimaryKey(t => t.CID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        PID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        Strength = c.String(),
                        GenericName = c.String(),
                        MfgLicNo = c.String(),
                        DARNo = c.String(),
                        ImageURL = c.String(),
                        PackSize = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CmpnyID = c.Int(nullable: false, identity: true),
                        CmpName = c.String(),
                        CRegisterName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CmpnyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CompanyID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Companies");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
