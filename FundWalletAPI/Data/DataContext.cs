using System;
using FundWalletAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FundsWallet_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Fund> Funds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Fund>().HasKey(p => p.FundId);
            modelBuilder.Entity<Fund>().Property(p => p.FundId).HasColumnName("FundId");

            modelBuilder.Entity<Fund>().Property(p => p.Name).HasColumnName("Name");

            modelBuilder.Entity<Fund>().Property(p => p.Quantity).HasColumnName("Quantity");
            modelBuilder.Entity<Fund>().Property(p => p.Quantity).HasColumnType("Integer");

            modelBuilder.Entity<Fund>().Property(p => p.UnitPrice).HasColumnName("UnitPrice");
            modelBuilder.Entity<Fund>().Property(p => p.UnitPrice).HasColumnType("Double(10,2)");
            base.OnModelCreating(modelBuilder);
        }
    }
}

