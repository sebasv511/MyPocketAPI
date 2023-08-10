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
        public DbSet<UserPassword> UsersPassword { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable(nameof(User));
            //modelBuilder.Entity<UserPassword>().ToTable(nameof(UserPassword));
            modelBuilder.Entity<User>()
            .HasMany(u => u.Passwords)
            .WithOne(up => up.User)
            .HasForeignKey(up => up.IdUser);

            base.OnModelCreating(modelBuilder);
        }
    }
}
