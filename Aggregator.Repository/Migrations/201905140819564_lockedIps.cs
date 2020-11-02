namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lockedIps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.lockedIps",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IpAddress = c.String(),
                        LokedTime = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.lockedIps");
        }
    }
}
