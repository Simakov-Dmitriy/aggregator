namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoustumTiketsCity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tikets", newName: "ChicagoTikets");
            CreateTable(
                "dbo.AugistineTikets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                        ClosingDate = c.DateTime(nullable: false),
                        ImageId = c.String(),
                        AdultCost = c.Double(nullable: false),
                        ChildCost = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        CouponId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CouponId);
            
            AddColumn("dbo.Coupons", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropIndex("dbo.AugistineTikets", new[] { "CouponId" });
            DropColumn("dbo.Coupons", "City");
            DropTable("dbo.AugistineTikets");
            RenameTable(name: "dbo.ChicagoTikets", newName: "Tikets");
        }
    }
}
