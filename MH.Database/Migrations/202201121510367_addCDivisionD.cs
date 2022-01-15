namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCDivisionD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Districts", "CountryId", "dbo.Countries");
            DropIndex("dbo.Districts", new[] { "CountryId" });
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        DivisionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DivisionID)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            AddColumn("dbo.Districts", "DivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Districts", "DivisionId");
            AddForeignKey("dbo.Districts", "DivisionId", "dbo.Divisions", "DivisionID", cascadeDelete: true);
            DropColumn("dbo.Districts", "CountryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Districts", "CountryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Districts", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Divisions", "CountryId", "dbo.Countries");
            DropIndex("dbo.Districts", new[] { "DivisionId" });
            DropIndex("dbo.Divisions", new[] { "CountryId" });
            DropColumn("dbo.Districts", "DivisionId");
            DropTable("dbo.Divisions");
            CreateIndex("dbo.Districts", "CountryId");
            AddForeignKey("dbo.Districts", "CountryId", "dbo.Countries", "CountryID", cascadeDelete: true);
        }
    }
}
