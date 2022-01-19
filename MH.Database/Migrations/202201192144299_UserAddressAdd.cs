namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddressAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UAddresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Type = c.Short(nullable: false),
                        Upazilla = c.Int(nullable: false),
                        VillageOrTown = c.String(),
                        RoadName = c.String(),
                        HouseName = c.String(),
                        HoldingNumber = c.String(),
                        Flat = c.String(),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UAddresses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UAddresses", new[] { "UserId" });
            DropTable("dbo.UAddresses");
        }
    }
}
