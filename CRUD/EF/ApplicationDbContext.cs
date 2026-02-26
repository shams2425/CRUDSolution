using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.EF;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Person> Persons { get; set; }


protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable("Person");
        modelBuilder.Entity<Person>().HasData(new Person
        {
            Id = 1,
            Name = "Tabrez",
            Age = 21,
            DateOfBirth = new DateTime(2004, 01, 25),
            Gender = "Male"
        });
    }
}