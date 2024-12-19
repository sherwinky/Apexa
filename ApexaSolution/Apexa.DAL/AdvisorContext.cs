using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Apexa.Data.Dto;
using Microsoft.EntityFrameworkCore;

namespace Apexa.DAL
{
    public class AdvisorContext: DbContext
    {
        private readonly string DbName = "AdvisorDb";
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: DbName);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Advisor>(rr =>
            {
                rr.HasKey(e => e.Id);
              
            });
        }
        public DbSet<Advisor> Advisors { get; set; }
    }
}
