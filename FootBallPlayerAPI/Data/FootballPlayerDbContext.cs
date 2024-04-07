using FootballPlayerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayerAPI.Data
{
    public class FootballPlayerDbContext : DbContext
    {
        public FootballPlayerDbContext(DbContextOptions<FootballPlayerDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
