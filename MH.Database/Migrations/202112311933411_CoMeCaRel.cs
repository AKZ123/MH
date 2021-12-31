namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoMeCaRel : DbMigration
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
                        Category_CID = c.Int(),
                        Company_CmpnyID = c.Int(),
                    })
                .PrimaryKey(t => t.PID)
                .ForeignKey("dbo.Categories", t => t.Category_CID)
                .ForeignKey("dbo.Companies", t => t.Company_CmpnyID)
                .Index(t => t.Category_CID)
                .Index(t => t.Company_CmpnyID);
            
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
            DropForeignKey("dbo.Products", "Company_CmpnyID", "dbo.Companies");
            DropForeignKey("dbo.Products", "Category_CID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Company_CmpnyID" });
            DropIndex("dbo.Products", new[] { "Category_CID" });
            DropTable("dbo.Companies");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
