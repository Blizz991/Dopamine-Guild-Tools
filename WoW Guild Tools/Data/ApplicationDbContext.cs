using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WoW_Guild_Tools.Models;


namespace WoW_Guild_Tools.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WowRace> Races { get; set; }
        public DbSet<WowClass> WowClasses { get; set; }
        public DbSet<WowSpec> WowSpecs { get; set; }
        public DbSet<Raider> Raiders { get; set; }
        public DbSet<Profession> Professions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Enum Parsing
            //modelBuilder
            //    .Entity<WowFaction>()
            //    .Property(e => e.Name)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (Faction)Enum.Parse(typeof(Faction), v)
            //    );

            //modelBuilder
            //    .Entity<WowRace>()
            //    .Property(e => e.Name)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (Race)Enum.Parse(typeof(Race), v)
            //    );

            //modelBuilder
            //    .Entity<WowClass>()
            //    .Property(e => e.Name)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (Class)Enum.Parse(typeof(Class), v)
            //    );

            //modelBuilder
            //    .Entity<WowSpec>()
            //    .Property(e => e.Name)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (Spec)Enum.Parse(typeof(Spec), v)
            //    );

            //modelBuilder
            //    .Entity<WowRole>()
            //    .Property(e => e.Name)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (WowSpecRole)Enum.Parse(typeof(WowSpecRole), v)
            //    );

            //modelBuilder
            //    .Entity<Profession>()
            //    .Property(e => e.Name)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (WowProfession)Enum.Parse(typeof(WowProfession), v)
            //    );
            #endregion EnumParsing

            #region Relations
            //modelBuilder.Entity<WowFaction>()
            //    .HasMany(wf => wf.Races)
            //    .WithOne(r => r.Faction);

            //modelBuilder.Entity<WowRaceClass>()
            //    .HasKey(wrc => new { wrc.WowRaceId, wrc.WowClassId });
            //modelBuilder.Entity<WowRaceClass>()
            //    .HasMany(wr => wr.WowRace)
            //    .WithMany(wc => wc.Classes)

            //modelBuilder.Entity<WowRace>()
            //    .HasMany(wr => wr.Classes)
            //    .WithMany(c => c.)
            #endregion Relations
        }
    }
}
