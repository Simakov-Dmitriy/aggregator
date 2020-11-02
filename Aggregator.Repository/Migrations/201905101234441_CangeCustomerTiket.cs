namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CangeCustomerTiket : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerTikets", "Cost", c => c.Double(nullable: false));
            AlterColumn("dbo.CustomerTikets", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerTikets", "Count", c => c.String());
            AlterColumn("dbo.CustomerTikets", "Cost", c => c.String());
        }
    }
}
