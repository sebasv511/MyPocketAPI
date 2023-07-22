using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPocketAPI.Models;

namespace MyPocketAPI.Data
{
    public class MyPocketDbContext : DbContext
    {
        public MyPocketDbContext (DbContextOptions<MyPocketDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyPocketAPI.Models.User> Users { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(User));
            base.OnModelCreating(modelBuilder);
        }
    }
}
