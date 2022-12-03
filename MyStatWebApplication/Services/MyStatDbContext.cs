using Microsoft.EntityFrameworkCore;
using MyStatWebApplication.Models;

namespace MyStatWebApplication.Services;

public class MyStatDbContext : DbContext
{
    public MyStatDbContext(DbContextOptions<MyStatDbContext> options) : base(options)
    {
        Database.EnsureCreated();
        // Database.EnsureDeleted();
    }

    public DbSet<Homework> Homeworks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Homework>().HasData(new List<Homework>
        {
            new()
            {
                Id = 1,
                Description = "hello",
                DateTime = DateTime.Now
            },
            new()
            {
                Id = 2,
                Description = "hello",
                DateTime = DateTime.Now
            },
            new()
            {
                Id = 3,
                Description = "hello",
                DateTime = DateTime.Now
            },
            new()
            {
                Id = 4,
                Description = "hello",
                DateTime = DateTime.Now
            },
            new()
            {
                Id = 5,
                Description = "hello",
                DateTime = DateTime.Now
            },
            new()
            {
                Id = 6,
                Description = "hello",
                DateTime = DateTime.Now
            },
            new()
            {
                Id = 7,
                Description = "hello",
                DateTime = DateTime.Now
            },
            new()
            {
                Id = 8,
                Description = "hello",
                DateTime = DateTime.Now
            },
            new()
            {
                Id = 9,
                Description = "hello",
                DateTime = DateTime.Now
            },
        });
    }
}