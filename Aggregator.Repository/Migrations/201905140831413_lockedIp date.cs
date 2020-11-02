namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lockedIpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.lockedIps", "LokedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.lockedIps", "LokedTime", c => c.DateTime(nullable: false));
        }
    }
}
