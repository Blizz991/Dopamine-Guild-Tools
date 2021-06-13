using Laraue.EfCoreTriggers.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoW_Guild_Tools.Models;
using WoW_Guild_Tools.Models.Enums;

namespace WoW_Guild_Tools.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Raider> Raiders { get; set; }
        public DbSet<RaidGroup> RaidGroups { get; set; }
        public DbSet<GroupRaider> GroupRaiders { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Recipe> Recipes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RaidGroup>()
                .Property(rg => rg.LastUpdated)
                .HasDefaultValueSql("getdate()");

            // https://stackoverflow.com/a/64757747 ?
            //modelBuilder.Entity<RaidGroup>()
            //    .AfterInsert(trigger => trigger
            //        .Action(triggerAction => triggerAction
            //            .Upsert(raidGroup => new { raidGroup.Id },
            //            insertedRaidGroup => new RaidGroup {))
        }

        //This currently does nothing?
        // https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is RaidGroup && e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                ((RaidGroup)entityEntry.Entity).LastUpdated = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}
