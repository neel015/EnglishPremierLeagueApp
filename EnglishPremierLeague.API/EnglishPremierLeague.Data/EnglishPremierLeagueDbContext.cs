using EnglishPremierLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.Data
{
    public class EnglishPremierLeagueDbContext : DbContext
    {
        public EnglishPremierLeagueDbContext(DbContextOptions<EnglishPremierLeagueDbContext> dbContextOptions): base(dbContextOptions)
        {

        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"");
        }
    }
}
