namespace cs460Final.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ItemsContext : DbContext
    {
        public ItemsContext()
            : base("name=ItemsContext")
        {
        }

        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.Seller)
                .WillCascadeOnDelete();
        }
    }
}
