using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace canteensystem.Models
{
    public class CanteenContext:DbContext
    {
        public CanteenContext(DbContextOptions<CanteenContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().Property(e => e.shoppingCar).HasConversion(
                v => JsonSerializer.Serialize(v, null),
                v => JsonSerializer.Deserialize<List<Food>>(v, null),
                new ValueComparer<ICollection<Food>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => (ICollection<Food>)c.ToList()));

            modelBuilder.Entity<Store>().Property(e => e.menu).HasConversion(
                v => JsonSerializer.Serialize(v, null),
                v => JsonSerializer.Deserialize<List<Food>>(v, null),
                new ValueComparer<ICollection<Food>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => (ICollection<Food>)c.ToList()));
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Food> Food { get; set; }
    }
}
