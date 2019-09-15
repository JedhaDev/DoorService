using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Door> Doors { get; set; }

        public RepositoryContext() : base("DBConnectionString")
        {
            Database.SetInitializer<RepositoryContext>(new RepositoryDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Door>()
            .Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
