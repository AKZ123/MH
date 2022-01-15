namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Countries", "ISOCountryCode", c => c.String());
            AddColumn("dbo.Countries", "DialingCoad", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Countries", "DialingCoad");
            DropColumn("dbo.Countries", "ISOCountryCode");
        }
    }
}
