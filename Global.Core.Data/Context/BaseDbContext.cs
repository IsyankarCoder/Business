using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Global.Core.Domain.Models;


namespace Global.Core.Data.Context
{
    public class BaseDbContext
        : DbContext
    {


        DbSet<Parameter> Parameters { get; set; }
        DbSet<ParameterGroup> ParameterGroups { get; set; }

        public BaseDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parameter>()
                .HasOne(x => x.ParameterGroup)
                .WithMany(c => c.Parameters)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

    }
}
