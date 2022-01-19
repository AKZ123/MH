namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSaleArea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSaleAreas",
                c => new
                    {
                        SaleAreaId = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        AreaStatus = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.SaleAreaId, t.UserID })
                .ForeignKey("dbo.SaleAreas", t => t.SaleAreaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.SaleAreaId)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.SaleAreas",
                c => new
                    {
                        SAID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AreaIncreaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SAID);
            
            AddColumn("dbo.ProductBatchUsers", "ProductStatus", c => c.Short(nullable: false));
            AddColumn("dbo.AspNetUsers", "ProfilePic", c => c.String());
            AddColumn("dbo.AspNetUsers", "AdmitDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProductBatchUsers", "Status");
            DropColumn("dbo.AspNetUsers", "PrifilePic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PrifilePic", c => c.String());
            AddColumn("dbo.ProductBatchUsers", "Status", c => c.Short(nullable: false));
            DropForeignKey("dbo.UserSaleAreas", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSaleAreas", "SaleAreaId", "dbo.SaleAreas");
            DropIndex("dbo.UserSaleAreas", new[] { "UserID" });
            DropIndex("dbo.UserSaleAreas", new[] { "SaleAreaId" });
            DropColumn("dbo.AspNetUsers", "AdmitDate");
            DropColumn("dbo.AspNetUsers", "ProfilePic");
            DropColumn("dbo.ProductBatchUsers", "ProductStatus");
            DropTable("dbo.SaleAreas");
            DropTable("dbo.UserSaleAreas");
        }
    }
}
