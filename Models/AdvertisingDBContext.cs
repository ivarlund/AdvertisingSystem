using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdvertisingSystem.Models
{
    public partial class AdvertisingDBContext : DbContext
    {
        public AdvertisingDBContext()
        {
        }

        public AdvertisingDBContext(DbContextOptions<AdvertisingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<Advertiser> Advertisers { get; set; }
        public virtual DbSet<BillingAdress> BillingAdresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tbl_ad");

                entity.Property(e => e.Id).HasColumnName("ad_id");

                entity.Property(e => e.AdPrice).HasColumnName("ad_adPrice");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("ad_content");

                entity.Property(e => e.ItemPrice).HasColumnName("ad_itemPrice");

                entity.Property(e => e.Publicist).HasColumnName("ad_publicist");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ad_title");

                entity.HasOne(d => d.Advertiser)
                    .WithMany(p => p.Ads)
                    .HasForeignKey(d => d.Publicist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ad_tbl_advertiser");
            });

            modelBuilder.Entity<Advertiser>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tbl_advertiser");

                entity.HasIndex(e => e.Subscriber, "UQ__tbl_adve__95FCB9302FC52730")
                    .IsUnique();

                entity.HasIndex(e => e.OrgNo, "UQ__tbl_adve__E6470F0BF0624B59")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("adv_id");

                entity.Property(e => e.Adress)
                    .HasMaxLength(100)
                    .HasColumnName("adv_adress");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("adv_city");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("adv_name");

                entity.Property(e => e.OrgNo).HasColumnName("adv_orgNo");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(100)
                    .HasColumnName("adv_phoneNo");

                entity.Property(e => e.Subscriber).HasColumnName("adv_subscriber");

                entity.Property(e => e.ZipCode).HasColumnName("adv_zipCode");
            });

            modelBuilder.Entity<BillingAdress>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tbl_billingAdress");

                entity.HasIndex(e => e.Recipient, "UQ__tbl_bill__D84A7C984124A76A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ba_id");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ba_adress");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ba_city");

                entity.Property(e => e.Recipient).HasColumnName("ba_recipient");

                entity.Property(e => e.ZipCode).HasColumnName("ba_zipCode");

                entity.HasOne(d => d.Advertiser)
                    .WithOne(p => p.BillingAdress)
                    .HasForeignKey<BillingAdress>(d => d.Recipient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_billingAdress");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
