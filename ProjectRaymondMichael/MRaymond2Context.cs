using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ProjectRaymondMichael
{
    public partial class MRaymond2Context : DbContext
    {

        public MRaymond2Context(DbContextOptions<MRaymond2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<spAffordable> spAffordables { get; set; } 
        public virtual DbSet<spTotalSales> spTotalSales { get; set; }
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<VwPurchase> VwPurchases { get; set; } = null!;

        public IConfiguration myconfig { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(myconfig.GetConnectionString("GalaxyDB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<spAffordable>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("spAfforable");

                entity.Property(e => e.Item)
                    .HasColumnName("name");

                entity.Property(e => e.Credits)
                    .HasColumnName("credits");
            });

            modelBuilder.Entity<spTotalSales>(entity =>
            { 
                entity.HasNoKey();
                entity.ToTable("spTotalSales");

                entity.Property(e => e.TotalCredits)
                    .HasColumnName("Total Credits");

                entity.Property(e => e.TotalCredits);
                entity.Property(e => e.Item)
                    .HasColumnName("Item");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__employee__AFB3EC6DABF6FD28");

                entity.ToTable("employees");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hireDate");

                entity.Property(e => e.HomePlanet)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("homePlanet");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.Credits).HasColumnName("credits");

                entity.Property(e => e.ImageSrc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("imageSrc");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales");

                entity.Property(e => e.SaleId).HasColumnName("saleID");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("date")
                    .HasColumnName("purchaseDate");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__empID__00200768");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__itemID__01142BA1");
            });


            modelBuilder.Entity<VwPurchase>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPurchases");

                entity.Property(e => e.DateOfPurchase)
                    .HasColumnType("date")
                    .HasColumnName("Date of Purchase");

                entity.Property(e => e.EmpiricalName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Empirical Name");

                entity.Property(e => e.Item)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
