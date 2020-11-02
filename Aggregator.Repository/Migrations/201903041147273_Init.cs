namespace Aggregator.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                        AuthorId = c.String(),
                        Counter = c.String(),
                        Link = c.String(),
                        ClosingDate = c.DateTime(nullable: false),
                        SpecialPropositionId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SpecialPropositions", t => t.SpecialPropositionId)
                .Index(t => t.SpecialPropositionId);
            
            CreateTable(
                "dbo.SpecialPropositions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                        ImageId = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tikets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                        Amount = c.String(),
                        ClosingDate = c.DateTime(nullable: false),
                        ImageId = c.String(),
                        CouponId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coupons", t => t.CouponId)
                .Index(t => t.CouponId);
            
            CreateTable(
                "dbo.Сustomer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Phone = c.String(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tikets", "CouponId", "dbo.Coupons");
            DropForeignKey("dbo.Coupons", "SpecialPropositionId", "dbo.SpecialPropositions");
            DropIndex("dbo.Tikets", new[] { "CouponId" });
            DropIndex("dbo.Coupons", new[] { "SpecialPropositionId" });
            DropTable("dbo.Сustomer");
            DropTable("dbo.Tikets");
            DropTable("dbo.SpecialPropositions");
            DropTable("dbo.Coupons");
        }
    }
}
