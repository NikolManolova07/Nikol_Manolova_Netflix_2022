using NF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Data.Context
{
    public class NetflixDbContext : DbContext
    {
        public NetflixDbContext() : base(@"Data Source=DESKTOP-1PNBOSB\SQLEXPRESS2019;Initial Catalog=NETFLIX;Integrated Security=True;Pooling=False")
        {

        }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
