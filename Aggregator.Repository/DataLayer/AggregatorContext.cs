namespace Aggregator.Repository
{
    using Aggregator.Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AggregatorContext : DbContext
    {
        public AggregatorContext()
            : base(Aggregator.Configuration.AppConfiguration.ConectionString)
        {
        }

        public virtual DbSet<ChicagoTiket> TiketsChicago { get; set; }
        public virtual DbSet<AugistineTiket> TiketsAugistine { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Ñustomer> Ñustomers { get; set; }
        public virtual DbSet<SpecialProposition> SpecialPropositions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<SelectedTicket> SelectedTickets { get; set; }
        public virtual DbSet<CustomerTiket> CustomerTikets { get; set; }
        public virtual DbSet<Museum> Museums { get; set; }
        public virtual DbSet<ProcessingRequest> ProcessingRequests { get; set; }
        public virtual DbSet<NotSpamUser> NotSpamUsers { get; set; }
        public virtual DbSet<lockedIp> lockedIps { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<ChicagoTiket>()
                .HasOptional<Coupon>(p => p.Coupon)
                .WithMany(p => p.Tikets)
                .HasForeignKey<string>(p => p.CouponId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpecialProposition>()
               .HasMany<Coupon>(p => p.Coupons)
               .WithOptional(p => p.SpecialProposition)
               .HasForeignKey<string>(p => p.SpecialPropositionId)
               .WillCascadeOnDelete(false);
        }
    }
}