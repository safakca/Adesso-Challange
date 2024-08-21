using AdessoWorldLeague.Services.Dtos;

namespace AdessoWorldLeague.Services;
//Abstract
public interface IDrawService
{
    Task<DrawResultDto> DrawTeamsAsync(int groupCount, string drawnBy);
}

