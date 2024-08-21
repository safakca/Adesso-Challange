namespace AdessoWorldLeague.Services.Dtos;

public class DrawResultDto
{
	public string DrawnBy { get; set; }
	public List<GroupDto> Groups { get; set; } = new List<GroupDto>();
}

