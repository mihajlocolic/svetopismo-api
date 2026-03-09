using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    public DbSet<Verse> Verses {get; set;}
    public DbSet<Book> Books {get; set;}

    public DbSet<Chapter> Chapters {get; set;}
}