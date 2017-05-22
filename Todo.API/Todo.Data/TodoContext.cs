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


            modelBuilder.Entity<Member>()
                .ToTable("Members");

            modelBuilder.Entity<Member>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Member>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Member>()
                .Property(s => s.Age)
                .IsRequired();

            modelBuilder.Entity<Member>()
                .HasOne(s => s.Team)
                .WithMany(s => s.Members);

            modelBuilder.Entity<Member>()
                .HasMany(s => s.Tasks)
                .WithOne(s => s.Owner);

            modelBuilder.Entity<Model.Task>()
                .ToTable("Tasks");

            modelBuilder.Entity<Model.Task>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Model.Task>()
                .Property(s => s.Due)
                .HasDefaultValue(DateTime.Now.AddDays(+1));

            modelBuilder.Entity<Model.Task>()
                .Property(s => s.Description)
                .IsRequired();

            modelBuilder.Entity<Model.Task>()
                .Property(s => s.Status)
                .HasDefaultValue(Status.Created);

            modelBuilder.Entity<Model.Task>()
                .HasOne(s => s.Owner)
                .WithMany(s => s.Tasks);

            modelBuilder.Entity<Team>()
                .ToTable("Teams");

            modelBuilder.Entity<Team>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Team>()
                .Property(s => s.Name)
                .HasMaxLength(120)
                .IsRequired();

            modelBuilder.Entity<Team>()
                .HasMany(s => s.Members)
                .WithOne(s => s.Team);
            
        }
    }
}
}
