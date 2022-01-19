namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersStoresUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserStores", "UserStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserStores", "UserStatus", c => c.Short(nullable: false));
        }
    }
}
