using AdessoWorldLeague.Data;
using AdessoWorldLeague.Models;
using AdessoWorldLeague.Services.Dtos;
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

    public async Task<DrawResultDto> DrawTeamsAsync(int groupCount, string drawnBy)
    {
        if (string.IsNullOrWhiteSpace(drawnBy))
        {
            throw new ArgumentException("DrawnBy parameter is required.");
        }

        if (groupCount != 4 && groupCount != 8)
        {
            throw new ArgumentException("Group count must be either 4 or 8.");
        }

        var allTeams = await _context.Teams.Include(t => t.Country).ToListAsync();

        var groups = GenerateGroupDtos(groupCount, allTeams);

        foreach (var group in groups)
        {
            foreach (var teamDto in group.Teams)
            {
                if (!await _context.Teams.AnyAsync(t => t.Name == teamDto.Name))
                {
                    var newTeam = new Team { Name = teamDto.Name };
                    _context.Teams.Add(newTeam);
                }
            }
        }

        await _context.SaveChangesAsync();

        var drawResult = new DrawResultDto
        {
            DrawnBy = drawnBy,
            Groups = groups
        };

        return drawResult;
    }


    private List<GroupDto> GenerateGroupDtos(int groupCount, List<Team> allTeams)
    {
        var teamsByCountry = allTeams
            .GroupBy(t => t.Country.Name)
            .ToDictionary(g => g.Key, g => g.ToList());

        var groups = new List<GroupDto>();

        for (int i = 0; i < groupCount; i++)
        {
            var group = new GroupDto
            {
                GroupName = ((char)('A' + i)).ToString(),
                Teams = new List<TeamDto>()
            };

            groups.Add(group);
        }

        var countryKeys = teamsByCountry.Keys.ToList();
        var shuffledCountryKeys = countryKeys.OrderBy(c => Guid.NewGuid()).ToList();

        int currentGroupIndex = 0;

        foreach (var countryKey in shuffledCountryKeys)
        {
            var teams = teamsByCountry[countryKey];

            if (teams.Count > groupCount)
            {
                foreach (var team in teams)
                {
                    groups[currentGroupIndex].Teams.Add(new TeamDto { Name = team.Name });

                    currentGroupIndex = (currentGroupIndex + 1) % groupCount;
                }
            }
            else
            {
                foreach (var team in teams)
                {
                    groups[currentGroupIndex].Teams.Add(new TeamDto { Name = team.Name });
                    currentGroupIndex = (currentGroupIndex + 1) % groupCount;
                }
            }
        }

        return groups;
    }
}

