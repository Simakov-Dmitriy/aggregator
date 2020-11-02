namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCounterCoupons : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Coupons", "Counter", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Coupons", "Counter", c => c.String());
        }
    }
}
