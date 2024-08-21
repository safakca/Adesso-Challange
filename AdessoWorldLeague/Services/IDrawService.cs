using AdessoWorldLeague.Models;

namespace AdessoWorldLeague.Services;
//Abstract
public interface IDrawService
{
    Task<DrawResult> DrawTeamsAsync(int groupCount, string drawnBy);
}

