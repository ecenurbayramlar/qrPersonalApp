using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace deneme.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost; database=rasttek; integrated security=true; Port=5432;User Id=postgres;Password=5trongPW1.;");
        }

        public DbSet<Personal> personals { get; set; }
        public DbSet<Qr> qrs { get; set; }
        public DbSet<Intime> intimes{get;set;}
        public DbSet<Outtime> outtimes { get; set; }
    }
}
