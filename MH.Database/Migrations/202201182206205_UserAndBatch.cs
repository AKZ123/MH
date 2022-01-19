namespace MH.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAndBatch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductBatchUsers",
                c => new
                    {
                        BatchId = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                        Stocks = c.String(),
                        EnrollDate = c.DateTime(nullable: false),
                        Status = c.Short(nullable: false),
                        Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.BatchId, t.UserID })
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.BatchId)
                .Index(t => t.UserID);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "PrifilePic", c => c.String());
            AddColumn("dbo.AspNetUsers", "NID", c => c.Long(nullable: false));
            AddColumn("dbo.AspNetUsers", "NIDPic", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Short(nullable: false));
            AddColumn("dbo.AspNetUsers", "FatherName", c => c.String());
            AddColumn("dbo.AspNetUsers", "MotherName", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserCode", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "ReferenceCode", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductBatchUsers", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductBatchUsers", "BatchId", "dbo.Batches");
            DropIndex("dbo.ProductBatchUsers", new[] { "UserID" });
            DropIndex("dbo.ProductBatchUsers", new[] { "BatchId" });
            DropColumn("dbo.AspNetUsers", "ReferenceCode");
            DropColumn("dbo.AspNetUsers", "UserCode");
            DropColumn("dbo.AspNetUsers", "MotherName");
            DropColumn("dbo.AspNetUsers", "FatherName");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "NIDPic");
            DropColumn("dbo.AspNetUsers", "NID");
            DropColumn("dbo.AspNetUsers", "PrifilePic");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.ProductBatchUsers");
        }
    }
}
