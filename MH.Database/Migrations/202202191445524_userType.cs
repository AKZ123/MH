namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UserCode", c => c.String());
            AlterColumn("dbo.AspNetUsers", "ReferenceCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ReferenceCode", c => c.Double());
            AlterColumn("dbo.AspNetUsers", "UserCode", c => c.Double());
        }
    }
}
