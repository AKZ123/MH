namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UAddressTypeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UAddresses", "Type", c => c.Short());
            AlterColumn("dbo.UAddresses", "Upazilla", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UAddresses", "Upazilla", c => c.Int(nullable: false));
            AlterColumn("dbo.UAddresses", "Type", c => c.Short(nullable: false));
        }
    }
}
