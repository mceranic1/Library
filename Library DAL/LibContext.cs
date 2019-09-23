using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_DAL
{
    public class LibContext : DbContext
    {
        public LibContext() : base() { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<AuthBooks> AuthBooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "User ID=postgres;Password=admin;Server=localhost;Port=5432;Database=library;Integrated Security=true;Pooling=true;"
                );
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  // prozivamo ga
            builder.Entity<Author>().HasQueryFilter(x => !x.Deleted);  // Deleted stavljamo na true putem ovoga, posto je inicijalno u konstruktoru postavljen na false
            builder.Entity<Book>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<Publisher>().HasQueryFilter(x => !x.Deleted);
        }
        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted && x.Entity is BaseClass))
            {
                entry.State = EntityState.Modified;
                entry.CurrentValues["Deleted"] = true;
            }
            return base.SaveChanges();
        }
    }
}
