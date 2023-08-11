using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPocketAPI.Data.Models;

namespace MyPocketAPI.Data
{
    public class MyPocketDbContext : DbContext
    {
        public MyPocketDbContext (DbContextOptions<MyPocketDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<Pocket> Pocket { get; set; }
        public DbSet<PocketDetail> PocketDetail { get; set; }
        public DbSet<Month> Month { get; set; }
        public DbSet<MonthDetail> MonthDetail { get; set; }
        public DbSet<Movement> Movements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<UserPassword>().ToTable(nameof(UserPassword));
            modelBuilder.Entity<Movement>().ToTable(nameof(Movement));

            base.OnModelCreating(modelBuilder);
        }
    }
}
