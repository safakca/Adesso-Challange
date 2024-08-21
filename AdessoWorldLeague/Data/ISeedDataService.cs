namespace AdessoWorldLeague.Data;

public interface ISeedDataService
{
    Task SeedAsync(AppDbContext context);
}

