namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersStores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserStores",
                c => new
                    {
                        StoreId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        UserStatus = c.Short(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreId, t.UserId })
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        StoreNong = c.String(),
                        Name = c.String(),
                        MapLocation = c.String(),
                        TradLicenID = c.String(),
                        TradLicenPic = c.String(),
                        PSellLicenID = c.String(),
                        PSellLicenPic = c.String(),
                        Upazilla = c.Int(nullable: false),
                        VillageOrTown = c.String(),
                        RoadName = c.String(),
                        MarketName = c.String(),
                        Flore = c.Short(nullable: false),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.StoreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserStores", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserStores", "StoreId", "dbo.Stores");
            DropIndex("dbo.UserStores", new[] { "UserId" });
            DropIndex("dbo.UserStores", new[] { "StoreId" });
            DropTable("dbo.Stores");
            DropTable("dbo.UserStores");
        }
    }
}
