namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyAdd : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Products", "CompanyID", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Company_CmpnyID", c => c.Int());
            CreateIndex("dbo.Products", "Company_CmpnyID");
            AddForeignKey("dbo.Products", "Company_CmpnyID", "dbo.Companies", "CmpnyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Company_CmpnyID", "dbo.Companies");
            DropIndex("dbo.Products", new[] { "Company_CmpnyID" });
            DropColumn("dbo.Products", "Company_CmpnyID");
            DropColumn("dbo.Products", "CompanyID");
            DropTable("dbo.Companies");
        }
    }
}
