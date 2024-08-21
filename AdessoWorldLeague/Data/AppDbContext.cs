using AdessoWorldLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<Team> Teams { get; set; }
	public DbSet<Group> Groups { get; set; }
	public DbSet<DrawResult> DrawResults {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>().ToTable("Teams");
        modelBuilder.Entity<Group>().ToTable("Groups");
        modelBuilder.Entity<DrawResult>().ToTable("DrawResults");

        base.OnModelCreating(modelBuilder);
    }
}

