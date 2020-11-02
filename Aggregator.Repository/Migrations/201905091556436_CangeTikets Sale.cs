namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CangeTiketsSale : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tikets", "Sale");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tikets", "Sale", c => c.Double(nullable: false));
        }
    }
}
