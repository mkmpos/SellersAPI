using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sellers.Domain.SellersAggregateModels;

namespace Sellers.API.Models
{
    public class SellersContext : DbContext
    {
        public SellersContext (DbContextOptions<SellersContext> options)
            : base(options)
        {
        }

        public DbSet<Sellers.Domain.SellersAggregateModels.Seller> Sellers { get; set; }
        public DbSet<Sellers.Domain.SellersAggregateModels.Role> Roles { get; set; }

        public DbSet<Sellers.Domain.SellersAggregateModels.Commission> Commissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>().ToTable("Seller");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Commission>().ToTable("Commission");

        }
    }
}
