namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCoustomerTiket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerTikets", "SuperPass", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerTikets", "Insurance", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerTikets", "Insurance");
            DropColumn("dbo.CustomerTikets", "SuperPass");
        }
    }
}
