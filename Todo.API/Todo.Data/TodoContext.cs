using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Todo.Model;

namespace Todo.Data
{
    public class TodoContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Model.Task> Tasks { get; set; }

        public TodoContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            //modelBuilder.Entity<Member>()
            //    .ToTable("Member");

            //modelBuilder.Entity<Member>()
            //    .Property(s => s.Id)
            //    .IsRequired();

            //modelBuilder.Entity<Member>()
            //    .Property(s => s.DateCreated)
            //    .HasDefaultValue(DateTime.Now);

            //modelBuilder.Entity<Member>()
            //    .Property(s => s.DateUpdated)
            //    .HasDefaultValue(DateTime.Now);

            //modelBuilder.Entity<Member>()
            //    .Property(s => s.Type)
            //    .HasDefaultValue(ScheduleType.Work);

            //modelBuilder.Entity<Member>()
            //    .Property(s => s.Status)
            //    .HasDefaultValue(ScheduleStatus.Valid);

            //modelBuilder.Entity<Member>()
            //    .HasOne(s => s.Creator)
            //    .WithMany(c => c.SchedulesCreated);

            //modelBuilder.Entity<User>()
            //  .ToTable("User");

            //modelBuilder.Entity<User>()
            //    .Property(u => u.Name)
            //    .HasMaxLength(100)
            //    .IsRequired();

            //modelBuilder.Entity<Attendee>()
            //  .ToTable("Attendee");

            //modelBuilder.Entity<Attendee>()
            //    .HasOne(a => a.User)
            //    .WithMany(u => u.SchedulesAttended)
            //    .HasForeignKey(a => a.UserId);

            //modelBuilder.Entity<Attendee>()
            //    .HasOne(a => a.Schedule)
            //    .WithMany(s => s.Attendees)
            //    .HasForeignKey(a => a.ScheduleId);

        }
    }
}
}
