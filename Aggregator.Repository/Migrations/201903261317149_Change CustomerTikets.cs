namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomerTikets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerTikets", "Cost", c => c.String());
            AddColumn("dbo.CustomerTikets", "Count", c => c.String());
            AddColumn("dbo.CustomerTikets", "Status", c => c.String());
            AddColumn("dbo.CustomerTikets", "AgeCategory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerTikets", "AgeCategory");
            DropColumn("dbo.CustomerTikets", "Status");
            DropColumn("dbo.CustomerTikets", "Count");
            DropColumn("dbo.CustomerTikets", "Cost");
        }
    }
}
