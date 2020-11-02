namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CangeCupon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coupons", "SaleProcent", c => c.Double(nullable: false));
            AddColumn("dbo.Coupons", "PromoCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coupons", "PromoCode");
            DropColumn("dbo.Coupons", "SaleProcent");
        }
    }
}
