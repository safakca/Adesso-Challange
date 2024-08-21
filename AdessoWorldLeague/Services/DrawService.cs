using AdessoWorldLeague.Data;
using AdessoWorldLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Services;
//Concrete
public class DrawService : IDrawService
{
    private readonly AppDbContext _context;

	public DrawService(AppDbContext context)
	{
        _context = context;
	}

    public async Task<DrawResult> DrawTeamsAsync(int groupCount, string drawnBy)
    {
        if (groupCount != 4 && groupCount != 8)
            throw new ArgumentException("Group count must be either  4 or 8.");

        var allTeams = await _context.Teams.ToListAsync();
        var groups = GenerateGroups(groupCount: groupCount, allTeams: allTeams);
        var drawResult = new DrawResult
        {
            DrawnBy = drawnBy,
            Groups = groups
        };

        _context.DrawResults.Add(drawResult);
        await _context.SaveChangesAsync();

        return drawResult;
    }

    private List<Group> GenerateGroups(int groupCount, List<Team> allTeams)
    {
        var groups = Enumerable.Range(0, groupCount)
            .Select(i => new Group { GroupName = ((char)('A' + i)).ToString() })
            .ToList();

        var teamsPerGroup = groupCount == 4 ? 8 : 4;

        var shuffledTeams = allTeams.OrderBy(t => Guid.NewGuid()).ToList();
        var countryGroups = shuffledTeams.GroupBy(t => t.Country)
                                         .ToDictionary(g => g.Key, g => new Queue<Team>(g));



        for (int i = 0; i < teamsPerGroup; i++)
        {
            foreach (var group in groups)
            {
                foreach (var country in countryGroups.Keys.ToList())
                {
                    if (countryGroups[country].Count > 0) {
                        group.Teams.Add(countryGroups[country].Dequeue());
                        break;
                    }
                }
            }
        }

        return groups;
    }
}

