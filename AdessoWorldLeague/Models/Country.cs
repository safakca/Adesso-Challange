namespace AdessoWorldLeague.Models;

public class Country : BaseEntity
{
	public string Name { get; set; }
	public ICollection<Team> Teams {get; set;}
}

