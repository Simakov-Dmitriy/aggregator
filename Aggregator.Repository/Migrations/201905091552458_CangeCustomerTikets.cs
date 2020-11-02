namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CangeCustomerTikets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerTikets", "Sale", c => c.Double());
            AddColumn("dbo.CustomerTikets", "SpesialPropositionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerTikets", "SpesialPropositionId");
            DropColumn("dbo.CustomerTikets", "Sale");
        }
    }
}
