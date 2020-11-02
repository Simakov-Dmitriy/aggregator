namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lockedIpcounter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.lockedIps", "Counter", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.lockedIps", "Counter");
        }
    }
}
