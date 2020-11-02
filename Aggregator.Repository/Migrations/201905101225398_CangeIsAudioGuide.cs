namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CangeIsAudioGuide : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerTikets", "IsAudioGuide", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerTikets", "IsAudioGuide");
        }
    }
}
