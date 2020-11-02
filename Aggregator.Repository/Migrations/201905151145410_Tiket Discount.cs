namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TiketDiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tikets", "Discount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tikets", "Discount");
        }
    }
}
