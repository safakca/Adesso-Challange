namespace AdessoWorldLeague.Services.Dtos;

public class GroupDto
{
	public string GroupName { get; set; }
	public List<TeamDto> Teams { get; set; } = new List<TeamDto>();
}

