using Microsoft.EntityFrameworkCore;
using AdessoWorldLeague.Models;

namespace AdessoWorldLeague.Data;

public class SeedDataService : ISeedDataService
{
    //Seed data
    public async Task SeedAsync(AppDbContext context)
    {
        if (!await context.Countries.AnyAsync())
        {
            context.Countries.AddRange
            (
                new Country { Id=1, Name = "Türkiye" },
                new Country { Id = 2, Name = "Almanya" },
                new Country { Id = 3, Name = "Fransa" },
                new Country { Id = 4, Name = "Hollanda" },
                new Country { Id = 5, Name = "Portekiz" },
                new Country { Id = 6, Name = "İtalya" },
                new Country { Id = 7, Name = "İspanya" },
                new Country { Id = 8, Name = "Belçika" }
            );
            await context.SaveChangesAsync();
        }

        if (!await context.Teams.AnyAsync())
        {
            context.Teams.AddRange(
                new Team { Id = 1, Name = "Adesso İstanbul", CountryId = 1 },
                new Team { Id = 2, Name = "Adesso Ankara", CountryId = 1 },
                new Team { Id = 3, Name = "Adesso İzmir", CountryId = 1 },
                new Team { Id = 4, Name = "Adesso Antalya", CountryId = 1 },
                new Team { Id = 5, Name = "Adesso Berlin", CountryId = 2 },
                new Team { Id = 6, Name = "Adesso Frankfurt", CountryId = 2 },
                new Team { Id = 7, Name = "Adesso Münih", CountryId = 2 },
                new Team { Id = 8, Name = "Adesso Dortmund", CountryId = 2 },
                new Team { Id = 9, Name = "Adesso Paris", CountryId = 3 },
                new Team { Id = 10, Name = "Adesso Marsilya", CountryId = 3 },
                new Team { Id = 11, Name = "Adesso Nice", CountryId = 3 },
                new Team { Id = 12, Name = "Adesso Lyon", CountryId = 3 },
                new Team { Id = 13, Name = "Adesso Amsterdam", CountryId = 4 },
                new Team { Id = 14, Name = "Adesso Rotterdam", CountryId = 4 },
                new Team { Id = 15, Name = "Adesso Lahey", CountryId = 4 },
                new Team { Id = 16, Name = "Adesso Eindhoven", CountryId = 4 },
                new Team { Id = 17, Name = "Adesso Lisbon", CountryId = 5 },
                new Team { Id = 18, Name = "Adesso Porto", CountryId = 5 },
                new Team { Id = 19, Name = "Adesso Braga", CountryId = 5 },
                new Team { Id = 20, Name = "Adesso Coimbra", CountryId = 5 },
                new Team { Id = 21, Name = "Adesso Roma", CountryId = 6 },
                new Team { Id = 22, Name = "Adesso Milano", CountryId = 6 },
                new Team { Id = 23, Name = "Adesso Venedik", CountryId = 6 },
                new Team { Id = 24, Name = "Adesso Napoli", CountryId = 6 },
                new Team { Id = 25, Name = "Adesso Sevilla", CountryId = 7 },
                new Team { Id = 26, Name = "Adesso Madrid", CountryId = 7 },
                new Team { Id = 27, Name = "Adesso Barselona", CountryId = 7 },
                new Team { Id = 28, Name = "Adesso Granada", CountryId = 7 },
                new Team { Id = 29, Name = "Adesso Brüksel", CountryId = 8 },
                new Team { Id = 30, Name = "Adesso Brugge", CountryId = 8 },
                new Team { Id = 31, Name = "Adesso Gent", CountryId = 8 },
                new Team { Id = 32, Name = "Adesso Ansver", CountryId = 8 }
            );
            await context.SaveChangesAsync();
        }
    }
}

