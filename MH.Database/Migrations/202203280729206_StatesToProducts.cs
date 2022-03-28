namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatesToProducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductStates", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductStates", "StateId", "dbo.States");
            DropIndex("dbo.ProductStates", new[] { "ProductId" });
            DropIndex("dbo.ProductStates", new[] { "StateId" });
            AddColumn("dbo.Products", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "StateId");
            AddForeignKey("dbo.Products", "StateId", "dbo.States", "SID", cascadeDelete: true);
            DropTable("dbo.ProductStates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductStates",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.StateId });
            
            DropForeignKey("dbo.Products", "StateId", "dbo.States");
            DropIndex("dbo.Products", new[] { "StateId" });
            DropColumn("dbo.Products", "StateId");
            CreateIndex("dbo.ProductStates", "StateId");
            CreateIndex("dbo.ProductStates", "ProductId");
            AddForeignKey("dbo.ProductStates", "StateId", "dbo.States", "SID", cascadeDelete: true);
            AddForeignKey("dbo.ProductStates", "ProductId", "dbo.Products", "PID", cascadeDelete: true);
        }
    }
}
