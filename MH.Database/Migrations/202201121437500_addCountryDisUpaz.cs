namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCountryDisUpaz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictID)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Upazilas",
                c => new
                    {
                        UpazilaID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UpazilaID)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Upazilas", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "CountryId", "dbo.Countries");
            DropIndex("dbo.Upazilas", new[] { "DistrictId" });
            DropIndex("dbo.Districts", new[] { "CountryId" });
            DropTable("dbo.Upazilas");
            DropTable("dbo.Districts");
            DropTable("dbo.Countries");
        }
    }
}
