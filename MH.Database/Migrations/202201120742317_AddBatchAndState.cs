namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBatchAndState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        BID = c.Int(nullable: false, identity: true),
                        BatchNo = c.String(),
                        MfgDate = c.DateTime(nullable: false),
                        ExpDate = c.DateTime(nullable: false),
                        Mrp = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BID)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductStates",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.StateId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        SID = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        PackSizeUnit = c.String(),
                    })
                .PrimaryKey(t => t.SID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductStates", "StateId", "dbo.States");
            DropForeignKey("dbo.ProductStates", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Batches", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductStates", new[] { "StateId" });
            DropIndex("dbo.ProductStates", new[] { "ProductId" });
            DropIndex("dbo.Batches", new[] { "ProductId" });
            DropTable("dbo.States");
            DropTable("dbo.ProductStates");
            DropTable("dbo.Batches");
        }
    }
}
