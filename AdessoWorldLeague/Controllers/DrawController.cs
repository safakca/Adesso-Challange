using AdessoWorldLeague.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdessoWorldLeague.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrawController : ControllerBase
{
    private readonly IDrawService _drawService;

    public DrawController(IDrawService drawService)
    {
        _drawService = drawService;
    }

    [HttpPost("draw")]
    public async Task<IActionResult> DrawTeams([FromQuery] int groupCount, [FromQuery] string drawnBy) {
        if (string.IsNullOrWhiteSpace(drawnBy))
            return BadRequest("DrawnBy parameter is required.");

        var result = await _drawService.DrawTeamsAsync(groupCount: groupCount, drawnBy: drawnBy);
        return Ok(result);
    }
}