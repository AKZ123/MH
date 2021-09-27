namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
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
                    })
                .PrimaryKey(t => t.CID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        PID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MrpPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackSize = c.Int(nullable: false),
                        Description = c.String(),
                        Category_CID = c.Int(),
                    })
                .PrimaryKey(t => t.PID)
                .ForeignKey("dbo.Categories", t => t.Category_CID)
                .Index(t => t.Category_CID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_CID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_CID" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
