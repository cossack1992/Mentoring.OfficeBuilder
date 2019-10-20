using Mentoring.OfficeBuilder.DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.OfficeBuilder.DAL
{
    public class OfficeDbContext : DbContext
    {
        public DbSet<DbItemModel> DbItems { get; set; }

        public DbSet<DbAreaModel> DbAreas { get; set; }

        public OfficeDbContext(DbContextOptions<OfficeDbContext> options) : base(options) 
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DbAreaModel>().HasMany(a => a.Groups).WithOne(i => i.Area).IsRequired();
            builder.Entity<DbGroupModel>().HasMany(a => a.Items).WithOne(i => i.Group).IsRequired();
            builder.Entity<DbAreaModel>().HasMany(a => a.MovedFromItems).WithOne(i => i.MoveToArea);
        }
    }
}
