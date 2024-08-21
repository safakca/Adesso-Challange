using Microsoft.EntityFrameworkCore;
using AdessoWorldLeague.Models;

namespace AdessoWorldLeague.Data;

public class SeedDataService : ISeedDataService
{
    public async Task SeedAsync(AppDbContext context)
    {
        //Seed data
        if (!await context.Teams.AnyAsync())
        {
            context.Teams.AddRange(
                new Team { Id = 1, Name = "Adesso İstanbul", Country = "Türkiye" },
                new Team { Id = 2, Name = "Adesso Ankara", Country = "Türkiye" },
                new Team { Id = 3, Name = "Adesso İzmir", Country = "Türkiye" },
                new Team { Id = 4, Name = "Adesso Antalya", Country = "Türkiye" },
                new Team { Id = 5, Name = "Adesso Berlin", Country = "Almanya" },
                new Team { Id = 6, Name = "Adesso Frankfurt", Country = "Almanya" },
                new Team { Id = 7, Name = "Adesso Münih", Country = "Almanya" },
                new Team { Id = 8, Name = "Adesso Dortmund", Country = "Almanya" },
                new Team { Id = 9, Name = "Adesso Paris", Country = "Fransa" },
                new Team { Id = 10, Name = "Adesso Marsilya", Country = "Fransa" },
                new Team { Id = 11, Name = "Adesso Nice", Country = "Fransa" },
                new Team { Id = 12, Name = "Adesso Lyon", Country = "Fransa" },
                new Team { Id = 13, Name = "Adesso Amsterdam", Country = "Hollanda" },
                new Team { Id = 14, Name = "Adesso Rotterdam", Country = "Hollanda" },
                new Team { Id = 15, Name = "Adesso Lahey", Country = "Hollanda" },
                new Team { Id = 16, Name = "Adesso Eindhoven", Country = "Hollanda" },
                new Team { Id = 17, Name = "Adesso Lisbon", Country = "Portekiz" },
                new Team { Id = 18, Name = "Adesso Porto", Country = "Portekiz" },
                new Team { Id = 19, Name = "Adesso Braga", Country = "Portekiz" },
                new Team { Id = 20, Name = "Adesso Coimbra", Country = "Portekiz" },
                new Team { Id = 21, Name = "Adesso Roma", Country = "İtalya" },
                new Team { Id = 22, Name = "Adesso Milano", Country = "İtalya" },
                new Team { Id = 23, Name = "Adesso Venedik", Country = "İtalya" },
                new Team { Id = 24, Name = "Adesso Napoli", Country = "İtalya" },
                new Team { Id = 25, Name = "Adesso Sevilla", Country = "İspanya" },
                new Team { Id = 26, Name = "Adesso Madrid", Country = "İspanya" },
                new Team { Id = 27, Name = "Adesso Barselona", Country = "İspanya" },
                new Team { Id = 28, Name = "Adesso Granada", Country = "İspanya" },
                new Team { Id = 29, Name = "Adesso Brüksel", Country = "Belçika" },
                new Team { Id = 30, Name = "Adesso Brugge", Country = "Belçika" },
                new Team { Id = 31, Name = "Adesso Gent", Country = "Belçika" },
                new Team { Id = 32, Name = "Adesso Ansver", Country = "Belçika" }
            );

            await context.SaveChangesAsync();
        }
    }
}

