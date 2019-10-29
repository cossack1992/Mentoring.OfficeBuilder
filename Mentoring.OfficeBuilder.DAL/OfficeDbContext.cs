using Mentoring.OfficeBuilder.DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.OfficeBuilder.DAL
{
    public class OfficeDbContext : DbContext
    {
        public DbSet<DbSvg> DbSvgs { get; set; }

        public DbSet<DbTransition> DbTransitions { get; set; }

        public OfficeDbContext(DbContextOptions<OfficeDbContext> options) : base(options) 
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DbSvg>().HasMany(a => a.Transitions).WithOne(i => i.Svg);
        }
    }
}
