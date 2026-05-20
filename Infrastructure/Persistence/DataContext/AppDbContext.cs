namespace Infrastructure.Persistence.DataContext;

using Domain.Entities;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set;}
    public DbSet<Book> Books { get; set;}
    public DbSet<Genre> Genres { get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
    }

}
