namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotSpamUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotSpamUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Phone = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProcessingRequests", "Name", c => c.String());
            AddColumn("dbo.ProcessingRequests", "Surname", c => c.String());
            DropColumn("dbo.ProcessingRequests", "MuseumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProcessingRequests", "MuseumId", c => c.String());
            DropColumn("dbo.ProcessingRequests", "Surname");
            DropColumn("dbo.ProcessingRequests", "Name");
            DropTable("dbo.NotSpamUsers");
        }
    }
}
