using System;
using Microsoft.EntityFrameworkCore;
using FinalProject.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinalProject.Data
{
	public class FinalProjectContext : DbContext
	{
        public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options)
        {

        }
        public DbSet<Players> players { get; set; }
        public DbSet<Teams> teams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Players>().ToTable("players");
            modelBuilder.Entity<Teams>().ToTable("teams");

        }
    }
}

