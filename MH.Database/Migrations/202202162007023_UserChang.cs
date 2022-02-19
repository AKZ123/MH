namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserChang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "NID", c => c.Long());
            AlterColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.Short());
            AlterColumn("dbo.AspNetUsers", "UserCode", c => c.Double());
            AlterColumn("dbo.AspNetUsers", "ReferenceCode", c => c.Double());
            AlterColumn("dbo.AspNetUsers", "AdmitDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "AdmitDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "ReferenceCode", c => c.Double(nullable: false));
            AlterColumn("dbo.AspNetUsers", "UserCode", c => c.Double(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.Short(nullable: false));
            AlterColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "NID", c => c.Long(nullable: false));
        }
    }
}
