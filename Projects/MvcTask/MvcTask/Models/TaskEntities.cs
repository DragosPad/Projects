using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcTask.Models
{
    public class TaskEntities : DbContext
    {
        public DbSet<ListGen> ListGens { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListGen>()
                .HasMany(j => j.Tasks)
                .WithOptional()
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<ListGen>()
            //    .HasMany(j => j.Tasks)
            //    .WithOptional(t => t.ListGenId)
            //    .WillCascadeOnDelete(true);
            //base.OnModelCreating(modelBuilder);
        
        }
      
    }
}