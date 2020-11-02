namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsUsed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerTikets", "IsUsed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerTikets", "IsUsed");
        }
    }
}
