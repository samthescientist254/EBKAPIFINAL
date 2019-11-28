using EventsService.DataAccess.EF.Configuration;
using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF
{
    public class EbkEventDbContextFinal3_:DbContext
    {
        public EbkEventDbContextFinal3_()
        {
        }

        public EbkEventDbContextFinal3_(DbContextOptions<EbkEventDbContextFinal3_> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Atendee> Atendees { get; set; }
        public DbSet<OriginCountry> Countries { get; set; }
        public DbSet<Sponsors> Sponsors { get; set; }
        public DbSet<Speakers> Speakers { get; set; }
        public DbSet<EventBags> Resources { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<EventDays> EventDays { get; set; }
        public DbSet<EventSessions> EventSessions { get; set; }
        public DbSet<Members> Membership { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<PasswordResetTokens> PasswordResetTokens { get; set; }
        public DbSet<EventLogs> EventLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Ignore();
            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.Entity<Sponsors>().HasOne(e => e.Event).WithMany(s => s.Sporsors);
            modelBuilder.Entity<Sponsors>().Property(s => s.Id).IsRequired();
            modelBuilder.Entity<Sponsors>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Sponsors>().Property(s => s.Image).HasDefaultValue(null);

            modelBuilder.Entity<Speakers>().HasOne(e => e.Event).WithMany(s => s.Speakers);
            modelBuilder.Entity<Speakers>().Property(s => s.Id).IsRequired();
            modelBuilder.Entity<Speakers>().Property(s => s.EventCode).IsRequired();
            modelBuilder.Entity<Speakers>().Property(s => s.Image).HasDefaultValue(null);
            // modelBuilder.Entity<Speakers>().Property(s => s.Image).;

            modelBuilder.Entity<Atendee>().HasOne(e => e.Event);
            modelBuilder.Entity<Atendee>().Property(s => s.Id).IsRequired();
            modelBuilder.Entity<Atendee>().Property(s => s.EbKRegNumber).IsRequired();

            modelBuilder.Entity<Messages>().Property(s => s.Id).IsRequired();
            modelBuilder.Entity<Messages>()
            .HasOne(a => a.Members);
            modelBuilder.Entity<Notes>().Property(s => s.Id).IsRequired();

            modelBuilder.Entity<EventDays>().Property(s => s.Id).IsRequired();

            modelBuilder.Entity<EventSessions>().Property(s => s.Id).IsRequired();
            modelBuilder.Entity<EventSessions>().Property(s => s.EventCode).IsRequired();

            modelBuilder.Entity<Members>().Property(s => s.Id).IsRequired();
            modelBuilder.Entity<Members>().Property(s => s.EbkRegNumber).IsRequired();
            modelBuilder.Entity<Members>().Property(s => s.Image).HasDefaultValue(null);
            //modelBuilder.Entity<Members>()
          //.HasOne(a => a.Message)
          //.WithOne(a => a.Members)
          //.HasForeignKey<Members>(c => c.Id)
          ;

            //modelBuilder.Entity<Members>().Property(s => s.Gender).();
            //modelBuilder.Entity<Members>().Property(s => s.Id).IsRequired();

        }
    }
}
