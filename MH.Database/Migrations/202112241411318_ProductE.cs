namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "BrandName", c => c.String());
            AddColumn("dbo.Products", "Strength", c => c.String());
            AddColumn("dbo.Products", "GenericName", c => c.String());
            AddColumn("dbo.Products", "MfgLicNo", c => c.String());
            AddColumn("dbo.Products", "DARNo", c => c.String());
            AddColumn("dbo.Products", "ImageURL", c => c.String());
            DropColumn("dbo.Products", "Name");
            DropColumn("dbo.Products", "MrpPrice");
            DropColumn("dbo.Products", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "MrpPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "ImageURL");
            DropColumn("dbo.Products", "DARNo");
            DropColumn("dbo.Products", "MfgLicNo");
            DropColumn("dbo.Products", "GenericName");
            DropColumn("dbo.Products", "Strength");
            DropColumn("dbo.Products", "BrandName");
        }
    }
}
