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

    [HttpPost("draw-teams")]
    public async Task<IActionResult> DrawTeams(int groupCount, string drawnBy)
    {
        try
        {
            var result = await _drawService.DrawTeamsAsync(groupCount, drawnBy);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}