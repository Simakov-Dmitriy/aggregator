namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTiket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tikets", "AdultCost", c => c.Double(nullable: false));
            AddColumn("dbo.Tikets", "ChildCost", c => c.Double(nullable: false));
            AddColumn("dbo.Tikets", "Sale", c => c.Double(nullable: false));
            DropColumn("dbo.Tikets", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tikets", "Amount", c => c.Double(nullable: false));
            DropColumn("dbo.Tikets", "Sale");
            DropColumn("dbo.Tikets", "ChildCost");
            DropColumn("dbo.Tikets", "AdultCost");
        }
    }
}
