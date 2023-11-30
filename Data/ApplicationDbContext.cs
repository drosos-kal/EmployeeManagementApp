using System;
using System.Collections.Generic;
using EmployeeManagementChallenge.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementChallenge.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Python", Details = "Knowledge of Python language", TimeCreated = DateTime.Now },
                new Skill { Id = 2, Name = "Java", Details = "Knowledge of Java programming language", TimeCreated = DateTime.Now },
                new Skill { Id = 3, Name = "HTML", Details = "Web Pages", TimeCreated = DateTime.Now },
                new Skill { Id = 4, Name = "CSS", Details = "Styling", TimeCreated = DateTime.Now },
                new Skill { Id = 5, Name = "JavaScript", Details = "DOM Handling", TimeCreated = DateTime.Now }
            );


            modelBuilder.Entity<Employee>().HasData(
                  new Employee { Id = 1, Firstname = "John", Lastname = "Doe", Skills = "1,2" },
                  new Employee { Id = 2, Firstname = "Alice", Lastname = "W" },
                  new Employee { Id = 3, Firstname = "Ross", Lastname = "Bob", Skills = "2,3" },
                  new Employee { Id = 4, Firstname = "Rachel", Lastname = "Green", Skills = "5" }
              );



        }
    }
}
