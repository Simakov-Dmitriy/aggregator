namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TiketAmount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tikets", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tikets", "Amount", c => c.String());
        }
    }
}
