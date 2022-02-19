namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userProN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nickname", c => c.String());
            AddColumn("dbo.AspNetUsers", "ReferenceUser", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserCode");
            DropColumn("dbo.AspNetUsers", "ReferenceCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ReferenceCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserCode", c => c.String());
            DropColumn("dbo.AspNetUsers", "ReferenceUser");
            DropColumn("dbo.AspNetUsers", "Nickname");
        }
    }
}
